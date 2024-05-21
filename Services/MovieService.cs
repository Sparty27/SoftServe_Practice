using SoftServe_Practice.Models;
using SoftServe_Practice.Repositories.Interfaces;
using SoftServe_Practice.Services.Interfaces;

namespace SoftServe_Practice.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _movieRepository.GetMoviesAsync();
        }

        public async Task<Movie> GetMoviesAsync(int id)
        {
            return await _movieRepository.GetMovieByIdAsync(id);
        }

        public async Task AddMovieAsync(Movie movie)
        {
            await _movieRepository.AddMovieAsync(movie);
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            await _movieRepository.UpdateMovieAsync(movie);
        }

        public async Task DeleteMovieAsync(Movie movie)
        {
            await _movieRepository.DeleteMovieAsync(movie.Id);
        }
    }
}
