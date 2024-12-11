using MongoDB.Driver;
using Pi3.Models;
using System.Text.Json;
using Pi3.Dtos;
public class TmdbService : ITmdbService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = Environment.GetEnvironmentVariable("apiKey", EnvironmentVariableTarget.User); 
    private readonly string _language = "pt-BR";
    private readonly ContextMongodb _context;

    public TmdbService(HttpClient httpClient, ContextMongodb contextMongodb)
    {
        _httpClient = httpClient;
        _context = contextMongodb;
    }

    private async Task<T> GetFromTmdb<T>(string endpoint)
    {
        var response = await _httpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }
    private async Task<string> GetFromTmdbString(string endpoint)
    {
        var response = await _httpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    private IEnumerable<MovieDto> EditFilm(ResponseMovieDto movieResponse)
    {
        movieResponse.Results = movieResponse.Results.Select(movie =>
        {
            List<Avaliacao> avaliacaos = _context.Avaliacao.Find(x => x.IdTmdb == movie.id && x.isActive).ToList();
            double somaMedia = 0;
            int total = 0;
            double media = 0;

            foreach (var avaliacao in avaliacaos)
            {
                somaMedia += avaliacao.Nota;
                total++;
            }
            if (somaMedia > 0)
            {
                media = somaMedia / total;
            }

            movie.vote_average = media;
            movie.vote_count = total;

            return movie;
        });
        
        return movieResponse.Results;
    }

    public async Task<ResponseMovieDto> GetMovieByCategory(int page, string category)
    {
        var movieResponse = await GetFromTmdb<ResponseMovieDto>($"https://api.themoviedb.org/3/movie/{category}?api_key={_apiKey}" +
            $"&language={_language}&page={page}");

        movieResponse.Results = EditFilm(movieResponse);

        return movieResponse;
    }

    public async Task<ResponseMovieDto> GetBySort(int page,
        int[]? genero,
        string? sortAno,
        bool? movieType)
    {
        string stringTmdb = $"https://api.themoviedb.org/3/discover/movie?api_key={_apiKey}&language={_language}&page={page}";

        if (genero != null && genero.Length > 0)
        {
            stringTmdb += $"&with_genres={string.Join(",", genero)}";
        }

        if (!string.IsNullOrWhiteSpace(sortAno))
        {
            stringTmdb += $"&primary_release_year={sortAno}";
        }

        if(movieType != null)
        {
            if(movieType is true)
            {
                string currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
                stringTmdb += $"&sort_by=release_date.desc&release_date.lte={currentDate}";
            }
            else
            {
                stringTmdb += $"&sort_by=release_date.asc";
            }
        }

        var movieResponse = await GetFromTmdb<ResponseMovieDto>(stringTmdb);

        movieResponse.Results = EditFilm(movieResponse);

        return movieResponse;
    }

    public async Task<ResponseMovieDto> SearchMoviesAsync(string query)
    {
        var movieResponse = await GetFromTmdb<ResponseMovieDto>($"https://api.themoviedb.org/3/search/movie?api_key={_apiKey}&language={_language}&query={Uri.EscapeDataString(query)}");

        movieResponse.Results = EditFilm(movieResponse);

        return movieResponse;
    }

    public async Task<string> GetMovieDetailsAsync(int movieId)
    {
        return await GetFromTmdbString($"https://api.themoviedb.org/3/movie/{movieId}?api_key={_apiKey}&language={_language}&append_to_response=videos,images,credits,watch/providers");
    }

    
}