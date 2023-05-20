global using Microsoft.AspNetCore.Mvc;
global using eCommerce_backend.Services.ActorService;
global using eCommerce_backend.Services.ProducerService;
using Microsoft.AspNetCore.Authorization;

namespace eCommerce_backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProducersController : ControllerBase
    {
        private readonly IProducerService service;
        public ProducersController(IProducerService service)
        {
            this.service = service;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetProducersDto>>>> Get()
        {
            return Ok(await service.GetAllProdcucers());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetProducersDto>>> GetById(int id)
        {
            return Ok(await service.GetProducerById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetProducersDto>>>> AddProducer(AddProducerDto producer)
        {
            return Ok(await service.AddProducer(producer));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetProducersDto>>> UpdateProducer(UpdateProducerDto producer)
        {
            return Ok(await service.UpdateProducer(producer));
        }
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<GetProducersDto>>>> DeleteProducer(int id)
        {
            return Ok(await service.DeleteProducer(id));
        }

    }
}
