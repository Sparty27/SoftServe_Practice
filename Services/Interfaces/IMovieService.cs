using SoftServe_Practice.Models;

namespace SoftServe_Practice.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie> GetMoviesAsync(int id);
        Task AddMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task DeleteMovieAsync(Movie movie);
    }
}
