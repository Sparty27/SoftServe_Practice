using Microsoft.AspNetCore.Mvc;
using SoftServe_Practice.Models;
using SoftServe_Practice.Services.Interfaces;

namespace SoftServe_Practice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("GetAllMovies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var movies = await _movieService.GetMoviesAsync();
            return Ok(movies);
        }

        [HttpPost]
        [Route("CreateMovie")]
        public async Task<ActionResult<Movie>> AddMovie(Movie movie)
        {
            await _movieService.AddMovieAsync(movie);
            return Ok(movie);
        }


        [HttpPut]
        [Route("UpdateMovie")]
        public async Task<ActionResult<Movie>> UpdateMovie(Movie movie)
        {
            await _movieService.UpdateMovieAsync(movie);
            return Ok(movie);
        }

        [HttpDelete]
        [Route("DeleteMovie")]
        public async Task<ActionResult<Movie>> DeleteMovie(Movie movie)
        {
            await _movieService.DeleteMovieAsync(movie);
            return Ok(movie);
        }
    }

}
