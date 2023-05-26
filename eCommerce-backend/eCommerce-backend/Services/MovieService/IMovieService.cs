using eCommerce_backend.Dtos.MovieDto;

namespace eCommerce_backend.Services.MovieService
{
    public interface IMovieService
    {
        Task<ServiceResponse<List<GetMoviesDto>>> GetAllMovies();
        Task<ServiceResponse<GetMoviesDto>> GetMovieById(int id);
        Task<ServiceResponse<List<GetMoviesDto>>> AddMovie(AddMovieDto movie);
        Task<ServiceResponse<GetMoviesDto>> UpdateMovie(UpdateMovieDto movie);
        Task<ServiceResponse<List<GetMoviesDto>>> DeleteMovie(int id);
        Task<ServiceResponse<List<GetMoviesDto>>> GetMoviesExceptOwned(int userId);
    }
}
