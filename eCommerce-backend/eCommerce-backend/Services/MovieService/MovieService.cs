using eCommerce_backend.Dtos.MovieDto;
using eCommerce_backend.Models;

namespace eCommerce_backend.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public MovieService(IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<ServiceResponse<List<GetMoviesDto>>> AddMovie(AddMovieDto movie)
        {
            var response = new ServiceResponse<List<GetMoviesDto>>();

            try
            {
                var _movie = mapper.Map<Movie>(movie);
                context.Movies.Add(_movie);
                await context.SaveChangesAsync();
                response.Data = await context.Movies.Select(m => mapper.Map<GetMoviesDto>(m)).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetMoviesDto>>> DeleteMovie(int id)
        {
            var response = new ServiceResponse<List<GetMoviesDto>>();
            try
            {
                var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);

                if (movie is null)
                    throw new Exception("Movie with Id:" + id + " is not found");

                context.Movies.Remove(movie);
                await context.SaveChangesAsync();

                response.Data = await context.Movies.Select(m => mapper.Map<GetMoviesDto>(m)).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetMoviesDto>>> GetAllMovies()
        {
            var response = new ServiceResponse<List<GetMoviesDto>>();
            try
            {
                var movies = await context.Movies.ToListAsync();
                response.Data = movies.Select(m => mapper.Map<GetMoviesDto>(m)).ToList();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetMoviesDto>> GetMovieById(int id)
        {
            var response = new ServiceResponse<GetMoviesDto>();
            try
            {
                var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);

                if (movie is null)
                    throw new Exception("Movie with Id:" + id + " is not found");

                response.Data = mapper.Map<GetMoviesDto>(movie);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetMoviesDto>> UpdateMovie(UpdateMovieDto movie)
        {
            var response = new ServiceResponse<GetMoviesDto>();
            try
            {
                var _movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == movie.Id);

                if (_movie is null)
                    throw new Exception("Movie with Id:" + movie.Id + " is not found");

                _movie.Price = movie.Price;
                _movie.ProducerId = movie.ProducerId;
                _movie.Actors = movie.Actors!.Select(id => context.Actors.FirstOrDefault(a => a.Id == id)).ToList()!;
                _movie.CinemaId = movie.CinemaId;
                _movie.DatePublished = movie.DatePublished;
                _movie.Description = movie.Description;
                _movie.Title = movie.Title;
                _movie.ImageURL = movie.ImageURL;
                _movie.Genre = movie.Genre;

                await context.SaveChangesAsync();
                response.Data = mapper.Map<GetMoviesDto>(_movie);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
