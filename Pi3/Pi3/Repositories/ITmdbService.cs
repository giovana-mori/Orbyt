public interface ITmdbService
{
    public Task<string> GetPopularMoviesAsync();
    public Task<string> GetNowPlayingMoviesAsync();
    public Task<string> GetUpcomingMoviesAsync();
    public Task<string> GetTopRatedMoviesAsync();
    public Task<string> GetTrendingMoviesAsync(string timeWindow);
    public Task<string> SearchMoviesAsync(string query);
    public Task<string> GetMovieDetailsAsync(int movieId);
}
