using eCommerce_backend.Dtos.MovieDto;
using eCommerce_backend.Services.MovieService;
using Microsoft.AspNetCore.Authorization;

namespace eCommerce_backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService service;
        public MoviesController(IMovieService service)
        {
            this.service = service;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetMoviesDto>>>> Get()
        {
            return Ok(await service.GetAllMovies());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetMoviesDto>>> GetMovieById(int id)
        {
            return Ok(await service.GetMovieById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetMoviesDto>>>> AddMovie(AddMovieDto movie)
        {
            return Ok(await service.AddMovie(movie));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetMoviesDto>>> UpdateMovie(UpdateMovieDto movie)
        {
            return Ok(await service.UpdateMovie(movie));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<GetMoviesDto>>>> DeleteMovie(int id)
        {
            return Ok(await service.DeleteMovie(id));
        }
    }
}
