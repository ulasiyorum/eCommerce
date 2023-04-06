using eCommerce_backend.Services.CinemaService;

namespace eCommerce_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CinemasController : ControllerBase
    {
        private readonly ICinemaService service;
        public CinemasController(ICinemaService service)
        {
            this.service = service;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCinemasDto>>>> GetAll()
        {
            return Ok(await service.GetAllCinemas());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCinemasDto>>> GetById(int id)
        {
            return Ok(await service.GetCinemaById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCinemasDto>>>> AddCinema(AddCinemaDto cinema)
        {
            return Ok(await service.AddCinema(cinema));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCinemasDto>>> UpdateCinema(UpdateCinemaDto cinema)
        {
            return Ok(await service.UpdateCinema(cinema));
        }
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<GetCinemasDto>>>> DeleteCinema(int id)
        {
            return Ok(await service.DeleteCinema(id));
        }
    }
}
