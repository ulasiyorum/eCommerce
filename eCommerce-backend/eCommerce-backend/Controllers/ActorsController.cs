global using eCommerce_backend.Dtos.Actor;
global using eCommerce_backend.Models;
using eCommerce_backend.Services.ActorService;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService service;
        public ActorsController(IActorService service)
        {
            this.service = service;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetActorsDto>>>> Get()
        {
            return Ok(await service.GetAllActors());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetActorsDto>>> GetById(int id)
        {
            return Ok(await service.GetActorById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetActorsDto>>>> AddActor(AddActorDto actor)
        {
            return Ok(await service.AddActor(actor));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetActorsDto>>>> UpdateActor(UpdateActorDto actor)
        {
            var response = await service.UpdateActor(actor);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<GetActorsDto>>>> DeleteActor(int id)
        {
            var response = await service.DeleteActor(id);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }


    }
}
