using eCommerce_backend.Dtos.User;

namespace eCommerce_backend.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
        Task<ServiceResponse<GetUserDto>> UpdateUser(UserUpdateDto update);
    }
}
