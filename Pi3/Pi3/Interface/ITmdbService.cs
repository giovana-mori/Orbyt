using Microsoft.AspNetCore.Mvc;
using Pi3.Dtos;

public interface ITmdbService
{
    public Task<ResponseMovieDto> GetMovieByCategory(int page, string category);
    public Task<ResponseMovieDto> GetBySort(
        int page,
        int[]? genero,
        string? sortAno,
        bool? movieType);
    public Task<ResponseMovieDto> SearchMoviesAsync(string query);
    public Task<string> GetMovieDetailsAsync(int movieId);
}
