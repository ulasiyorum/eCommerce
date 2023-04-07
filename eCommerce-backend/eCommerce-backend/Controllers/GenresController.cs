using eCommerce_backend.Services.GenreService;

namespace eCommerce_backend.Controllers
{
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
