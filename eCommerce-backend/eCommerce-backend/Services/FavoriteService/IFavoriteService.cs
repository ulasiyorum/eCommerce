using eCommerce_backend.Dtos.MovieDto;

namespace eCommerce_backend.Services.FavoriteService;

public interface IFavoriteService
{
    Task<ServiceResponse<GetMoviesDto>> Add(AddFavoriteDto favoriteDto);
    Task<ServiceResponse<List<GetMoviesDto>>> GetFavoriteMoviesByUserId(int id);
    Task<ServiceResponse<GetMoviesDto>> Delete(int userId,int movieId);
}