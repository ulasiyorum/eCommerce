using eCommerce_backend.Services.GenreService;
using Microsoft.AspNetCore.Authorization;

namespace eCommerce_backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GenresController : ControllerBase
    {
        public readonly IGenreService service;
        public GenresController(IGenreService s)
        {
            service = s;
        }
        [HttpGet("GetAll")]
        public ActionResult<List<GetGenresDto>> GetAll()
        {
            return Ok(service.GetAll());
        }
    }
}
