using eCommerce_backend.Models;

namespace eCommerce_backend.Services.GenreService
{
    public class GenreService : IGenreService
    {
        public List<GetGenresDto> GetAll()
        {
            var genres = new List<GetGenresDto>();
            foreach(MovieType genre in Enum.GetValues(typeof(MovieType)))
            {
                int genreId = (int)genre;

                GetGenresDto dto = new GetGenresDto
                {
                    GenreId = genreId,
                    GenreName = genre.ToString()
                };

                genres.Add(dto);
            }

            return genres;
        }
    }
}
