global using eCommerce_backend.Dtos.Genres;

namespace eCommerce_backend.Services.GenreService
{
    public interface IGenreService
    {
        List<GetGenresDto> GetAll();
    }
}
