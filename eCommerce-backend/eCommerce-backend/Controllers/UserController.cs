global using eCommerce_backend.Dtos.Actor;
global using eCommerce_backend.Models;
using eCommerce_backend.Dtos.User;
using eCommerce_backend.Services.UserService;
using Microsoft.AspNetCore.Authorization;


namespace eCommerce_backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetUser(int id)
        {
            return Ok(await _service.GetById(id));
        }

    }
}