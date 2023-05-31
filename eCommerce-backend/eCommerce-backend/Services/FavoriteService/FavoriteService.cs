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
                .Include(m => m.Actors)
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

            response.Data = new GetMoviesDto
            {
                Actors = movie.Actors.Select(a => a.ActorId).ToList(),
                Description = movie.Description,
                Genre = movie.Genre,
                Id = movie.Id,
                Price = movie.Price,
                Title = movie.Title,
                CinemaId = movie.CinemaId,
                DatePublished = movie.DatePublished,
                ProducerId = movie.ProducerId
            };


        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }

        return response;
    }

    public async Task<ServiceResponse<List<GetMoviesDto>>> GetFavoriteMoviesByUserId(int id)
    {
        var response = new ServiceResponse<List<GetMoviesDto>>();
        try
        {
            var user = await _context.Users
                .Include(u => u.FavoriteMoviesList)
                .ThenInclude(m => m.Movie)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
                throw new Exception("User Not Found");
            response.Data = user.FavoriteMoviesList.Select(m => new GetMoviesDto
            {
                Actors = m.Movie!.Actors.Select(a => a.ActorId).ToList(),
                Description = m.Movie.Description,
                Genre = m.Movie.Genre,
                Id = m.Movie.Id,
                Price = m.Movie.Price,
                Title = m.Movie.Title,
                CinemaId = m.Movie.CinemaId,
                DatePublished = m.Movie.DatePublished,
                ProducerId = m.Movie.ProducerId
            }).ToList();
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }

        return response;
    }

    public async Task<ServiceResponse<List<GetMoviesDto>>> Delete(int userId, int movieId)
    {
        var response = new ServiceResponse<List<GetMoviesDto>>();
        try
        {
            var user = await _context.Users
                .Include(u => u.FavoriteMoviesList)
                .ThenInclude(m => m.Movie)
                .FirstOrDefaultAsync(u => u.Id == userId);
            
            if(user is null)
                throw new Exception("User Not Found");
            
            var item = user.FavoriteMoviesList.FirstOrDefault(m => m.MovieId == movieId);
            if(item is null)
                throw new Exception("Movie does not exist in the favorite list");
            
            user.FavoriteMoviesList.Remove(item);
            await _context.SaveChangesAsync();

            response.Data = user.FavoriteMoviesList.Select(fm => new GetMoviesDto
            {
                Actors = fm.Movie!.Actors.Select(a => a.ActorId).ToList(),
                Description = fm.Movie.Description,
                Genre = fm.Movie.Genre,
                Id = fm.Movie.Id,
                Price = fm.Movie.Price,
                Title = fm.Movie.Title,
                CinemaId = fm.Movie.CinemaId,
                DatePublished = fm.Movie.DatePublished,
                ProducerId = fm.Movie.ProducerId
            }).ToList();
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }

        return response;
    }
}