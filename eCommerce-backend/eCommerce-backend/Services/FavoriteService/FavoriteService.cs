using eCommerce_backend.Dtos.MovieDto;

namespace eCommerce_backend.Services.FavoriteService;

public class FavoriteService : IFavoriteService
{
    private readonly DataContext _context;

    public FavoriteService(DataContext context)
    {
        _context = context;
    }
    
    
    public async Task<ServiceResponse<GetMoviesDto>> Add(AddFavoriteDto favoriteDto)
    {
        var response = new ServiceResponse<GetMoviesDto>();
        try
        {
            var user = await _context.Users
                .Include(u => u.FavoriteMoviesList)
                .FirstOrDefaultAsync(u => u.Id == favoriteDto.UserId);
            if (user is null)
                throw new Exception("User Not Found");
            var movie = await _context.Movies
                .Include(m => m.UserFavoriteMoviesList)
                .FirstOrDefaultAsync(m => m.Id == favoriteDto.MovieId);
            if (movie is null)
                throw new Exception("Movie Not Found");

            var userFavoriteMovie = new UserFavoriteMovies
            {
                MovieId = favoriteDto.MovieId,
                UserId = favoriteDto.UserId
            };
            
            await _context.UserFavoriteMovies.AddAsync(userFavoriteMovie);
            await _context.SaveChangesAsync();            
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }

        return response;
    }

    public Task<ServiceResponse<List<GetMoviesDto>>> GetFavoriteMoviesByUserId(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<GetMoviesDto>> Delete(int userId, int movieId)
    {
        throw new NotImplementedException();
    }
}