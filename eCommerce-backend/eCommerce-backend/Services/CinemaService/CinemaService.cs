global using eCommerce_backend.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace eCommerce_backend.Services.CinemaService
{
    public class CinemaService : ICinemaService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public CinemaService(IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<ServiceResponse<List<GetCinemasDto>>> AddCinema(AddCinemaDto cinema)
        {
            var response = new ServiceResponse<List<GetCinemasDto>>();
            var _cinema = mapper.Map<Cinema>(cinema);
            context.Cinemas.Add(_cinema);
            await context.SaveChangesAsync();
            response.Data = await context.Cinemas.Select(c => mapper.Map<GetCinemasDto>(c)).ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<List<GetCinemasDto>>> DeleteCinema(int id)
        {
            var response = new ServiceResponse<List<GetCinemasDto>>();
            try
            {
                var cinema = await context.Cinemas.FirstOrDefaultAsync(c => c.Id == id);

                if (cinema is null)
                    throw new Exception("Cinema with Id:" + id + " is not found");

                context.Cinemas.Remove(cinema);
                await context.SaveChangesAsync();
                response.Data = await context.Cinemas.Select(c => mapper.Map<GetCinemasDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetCinemasDto>>> GetAllCinemas()
        {
            var response = new ServiceResponse<List<GetCinemasDto>>();
            try
            {
                var cinemas = await context.Cinemas.ToListAsync();
                response.Data = cinemas.Select(c => mapper.Map<GetCinemasDto>(c)).ToList();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetCinemasDto>> GetCinemaById(int id)
        {
            var response = new ServiceResponse<GetCinemasDto>();
            try
            {
                var cinema = await context.Cinemas.FirstOrDefaultAsync(c => c.Id == id);
                response.Data = mapper.Map<GetCinemasDto>(cinema);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetCinemasDto>> UpdateCinema(UpdateCinemaDto cinema)
        {
            var response = new ServiceResponse<GetCinemasDto>();
            try
            {
                var _cinema = await context.Cinemas.FirstOrDefaultAsync(c => c.Id == cinema.Id);

                if (_cinema is null)
                    throw new Exception("Cinema with Id:" + cinema.Id + " is not found");

                _cinema.ServiceRate = cinema.ServiceRate;
                _cinema.CinemaLogo = cinema.CinemaLogo;
                _cinema.Name = cinema.Name;
                _cinema.Movies = cinema.Movies;

                await context.SaveChangesAsync();
                response.Data = mapper.Map<GetCinemasDto>(_cinema);

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
