using eCommerce_backend.Dtos.User;

namespace eCommerce_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authRepo;
        public AuthController(IAuthRepository auth)
        {
            this.authRepo = auth;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await authRepo.Register(
                new User { Username = request.Username, }, request.Password
            );

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(UserLoginDto request)
        {
            var response = await authRepo.Login(
                request.Username, request.Password
            );

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> UpdateUser(UserUpdateDto user)
        {
            return Ok(await authRepo.UpdateUser(user));
        }
    }
}

