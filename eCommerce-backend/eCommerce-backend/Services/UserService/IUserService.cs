using eCommerce_backend.Dtos.User;

namespace eCommerce_backend.Services.UserService;

public interface IUserService
{
    Task<ServiceResponse<GetUserDto>> GetById(int id);
}