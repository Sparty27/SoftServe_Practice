using Microsoft.AspNetCore.Mvc;
using SoftServe_Practice.Models;
using SoftServe_Practice.Repositories.Interfaces;
using SoftServe_Practice.Services.Interfaces;

namespace SoftServe_Practice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMovieRepository _movieRepository;


        public MoviesController(IMovieService movieService, IMovieRepository movieRepository)
        {
            _movieService = movieService;
            _movieRepository = movieRepository;
        }

        [HttpGet]
        [Route("GetAllMovies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var movies = await _movieService.GetMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("GetNewMovies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetNewReleases()
        {
            var newReleases = await _movieRepository.GetNewReleasesAsync();
            return Ok(newReleases);
        }

        [HttpPost]
        [Route("CreateMovie")]
        public async Task<ActionResult<Movie>> AddMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _movieService.AddMovieAsync(movie);
            return Ok(movie);
        }


        [HttpPut]
        [Route("UpdateMovie")]
        public async Task<ActionResult<Movie>> UpdateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _movieService.UpdateMovieAsync(movie);
            return Ok(movie);
        }

        [HttpDelete]
        [Route("DeleteMovie")]
        public async Task<ActionResult<Movie>> DeleteMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _movieService.DeleteMovieAsync(movie);
            return Ok(movie);
        }
    }

}
