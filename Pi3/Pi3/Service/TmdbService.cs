using MongoDB.Driver;
using Pi3.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using Pi3.Repositories.Service;

namespace Pi3.Service
{
    public class TmdbService : ITmdbService
    {
        private readonly IMovieService _movieService;
        private readonly string _apiKey;
        private readonly ContextMongodb _context;
        public TmdbService(IConfiguration configuration, IMovieService movieService, ContextMongodb context)
        {
            _apiKey = configuration["TmdbApi:ApiKey"];
            _movieService = movieService;
            _context = context;
        }

        public async Task<List<Movie>> GetMoviesFromTmdbAsync(string category)
        {
            string url = category switch
            {
                "FilmesPopulares" => "https://api.themoviedb.org/3/movie/popular",
                "FilmesLancamentos" => "https://api.themoviedb.org/3/movie/now_playing",
                "FilmesEmCartaz" => "https://api.themoviedb.org/3/movie/now_playing",
                "FilmesMelhoresAvaliados" => "https://api.themoviedb.org/3/movie/top_rated",
                "FilmesTrendingDia" => "https://api.themoviedb.org/3/trending/movie/day",
                "FilmesTrendingSemana" => "https://api.themoviedb.org/3/trending/movie/week",
                _ => throw new ArgumentException("Categoria inválida")
            };

            var client = new RestClient(url);
            var request = new RestRequest();
            request.AddParameter("api_key", _apiKey);
            request.AddParameter("language", "pt-BR");
            var response = await client.GetAsync(request);

            var filmes = new List<Movie>();

            if (response.IsSuccessful)
            {
                var json = JObject.Parse(response.Content);
                var results = json["results"].ToList();

                foreach (var result in results)
                {
                    var filme = new Movie
                    {
                        IdTmdb = (int)result["id"],
                        Titulo = result["title"].ToString(),
                        Sinopse = result["overview"].ToString(),
                        DataLancamento = DateTime.Parse(result["release_date"].ToString()),
                        Duracao = result["runtime"]?.ToObject<int>() ?? 0,
                        MediaVotos = result["vote_average"].ToObject<double>(),
                        ContagemVotos = result["vote_count"].ToObject<int>(),
                        CaminhoPoster = result["poster_path"].ToString(),
                        CaminhoBackdrop = result["backdrop_path"]?.ToString() ?? string.Empty,
                        Generos = result["genre_ids"].ToObject<List<int>>().ConvertAll(g => g.ToString())
                    };

                    var trailersResponse = await GetTrailersAsync(filme.IdTmdb);
                    filme.Trailers = trailersResponse;

                    var elencoResponse = await GetElencoAsync(filme.IdTmdb);
                    filme.Elenco = elencoResponse;

                    await GetBudgetAndRevenueAsync(filme);
                    filme.Providers = await GetWhereToWatchAsync(filme.IdTmdb);
                    filme.PalavrasChave = await GetKeywordsAsync(filme.IdTmdb);

                    filmes.Add(filme);

                    await SaveMovieToCollectionAsync(filme, category);
                }
            }

            return filmes;
        }
        public async Task GetBudgetAndRevenueAsync(Movie filme)
        {
            var client = new RestClient($"https://api.themoviedb.org/3/movie/{filme.IdTmdb}");
            var request = new RestRequest();
            request.AddParameter("api_key", _apiKey);
            var response = await client.GetAsync(request);

            if (response.IsSuccessful)
            {
                var json = JObject.Parse(response.Content);
                filme.Orcamento = json["budget"]?.ToObject<long>() ?? 0;
                filme.Receita = json["revenue"]?.ToObject<long>() ?? 0;
            }
        }
        public async Task<List<Provider>> GetWhereToWatchAsync(int idTmdb)
        {
            var client = new RestClient($"https://api.themoviedb.org/3/movie/{idTmdb}/watch/providers");
            var request = new RestRequest();
            request.AddParameter("api_key", _apiKey);
            var response = await client.GetAsync(request);

            var providers = new List<Provider>();

            if (response.IsSuccessful)
            {
                var json = JObject.Parse(response.Content);
                var results = json["results"]?["BR"]?["flatrate"] ?? new JArray();

                foreach (var provider in results)
                {
                    providers.Add(new Provider
                    {
                        Nome = provider["provider_name"]?.ToString(),
                        LogoCaminho = provider["logo_path"]?.ToString()
                    });
                }
            }

            return providers;
        }
        public async Task<List<string>> GetKeywordsAsync(int idTmdb)
        {
            var client = new RestClient($"https://api.themoviedb.org/3/movie/{idTmdb}/keywords");
            var request = new RestRequest();
            request.AddParameter("api_key", _apiKey);
            var response = await client.GetAsync(request);

            var keywords = new List<string>();

            if (response.IsSuccessful)
            {
                var json = JObject.Parse(response.Content);
                var results = json["keywords"]?.ToList();

                if (results != null)
                {
                    foreach (var keyword in results)
                    {
                        keywords.Add(keyword["name"].ToString());
                    }
                }
            }

            return keywords;
        }


        public async Task<List<Trailer>> GetTrailersAsync(int idTmdb)
        {
            var client = new RestClient($"https://api.themoviedb.org/3/movie/{idTmdb}/videos");
            var request = new RestRequest();
            request.AddParameter("api_key", _apiKey);
            var response = await client.GetAsync(request);

            var trailers = new List<Trailer>();

            if (response.IsSuccessful)
            {
                var json = JObject.Parse(response.Content);
                var results = json["results"].ToList();

                foreach (var result in results)
                {
                    var trailer = new Trailer
                    {
                        Id = result["id"].ToString(),
                        Nome = result["name"].ToString(),
                        Tipo = result["type"].ToString(),
                        Site = result["site"].ToString(),
                        Chave = result["key"].ToString(),
                        LinkYouTube = result["site"].ToString() == "YouTube" ? $"https://www.youtube.com/watch?v={result["key"]}" : string.Empty
                    };
                    trailers.Add(trailer);
                }
            }

            return trailers;
        }

        public async Task<List<Ator>> GetElencoAsync(int idTmdb)
        {
            var client = new RestClient($"https://api.themoviedb.org/3/movie/{idTmdb}/credits");
            var request = new RestRequest();
            request.AddParameter("api_key", _apiKey);
            var response = await client.GetAsync(request);

            var elenco = new List<Ator>();

            if (response.IsSuccessful)
            {
                var json = JObject.Parse(response.Content);
                var cast = json["cast"].ToList();

                foreach (var member in cast)
                {
                    var ator = new Ator
                    {
                        Id = (int)member["id"],
                        Nome = member["name"].ToString(),
                        Personagem = member["character"].ToString(),
                        FotoCaminho = member["profile_path"]?.ToString() ?? string.Empty
                    };
                    elenco.Add(ator);
                }
            }

            return elenco;
        }

        private async Task SaveMovieToCollectionAsync(Movie filme, string category)
        {
            var collection = _context.GetMovieCollectionByCategory(category);

            await collection.InsertOneAsync(filme);
        }
    }
}
