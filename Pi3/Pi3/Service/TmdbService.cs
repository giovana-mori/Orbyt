using MongoDB.Driver;
using Pi3.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using Pi3.Repositories.Service;
using System.Net.Http;
using System.Threading.Tasks;
public class TmdbService : ITmdbService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "7defae6b176ce3140a5cc0847375679f";
    private readonly string _language = "pt-BR";

    public TmdbService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private async Task<string> GetFromTmdbAsync(string endpoint)
    {
        var response = await _httpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public Task<string> GetPopularMoviesAsync() =>
        GetFromTmdbAsync($"https://api.themoviedb.org/3/movie/popular?api_key={_apiKey}&language={_language}");

    public Task<string> GetNowPlayingMoviesAsync() =>
        GetFromTmdbAsync($"https://api.themoviedb.org/3/movie/now_playing?api_key={_apiKey}&language={_language}");

    public Task<string> GetUpcomingMoviesAsync() =>
        GetFromTmdbAsync($"https://api.themoviedb.org/3/movie/upcoming?api_key={_apiKey}&language={_language}");

    public Task<string> GetTopRatedMoviesAsync() =>
        GetFromTmdbAsync($"https://api.themoviedb.org/3/movie/top_rated?api_key={_apiKey}&language={_language}");

    public Task<string> GetTrendingMoviesAsync(string timeWindow) =>
        GetFromTmdbAsync($"https://api.themoviedb.org/3/trending/movie/{timeWindow}?api_key={_apiKey}&language={_language}");

    public Task<string> SearchMoviesAsync(string query) =>
        GetFromTmdbAsync($"https://api.themoviedb.org/3/search/movie?api_key={_apiKey}&language={_language}&query={Uri.EscapeDataString(query)}");

    public Task<string> GetMovieDetailsAsync(int movieId) =>
        GetFromTmdbAsync($"https://api.themoviedb.org/3/movie/{movieId}?api_key={_apiKey}&language={_language}&append_to_response=videos,images,credits,watch/providers");
}