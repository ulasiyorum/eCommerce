using eCommerce_backend.Dtos.User;

namespace eCommerce_backend.Services.UserService;

public class UserService : IUserService
{
    private readonly DataContext _dataContext;
    public UserService(DataContext context)
    {
        _dataContext = context;
    }
    
    
    public async Task<ServiceResponse<GetUserDto>> GetById(int id)
    {
        var response = new ServiceResponse<GetUserDto>();
        try
        {
            var user = await _dataContext.Users
                .Include(u => u.Movies)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
                throw new Exception("User with ID " + id + " not found");
            response.Data = new GetUserDto()
            {
                Id = user.Id,
                Username = user.Username,
                OwnedMovies = user.Movies.Select(m => m.MovieId).ToList(),
            };
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }

        return response;
    }
}