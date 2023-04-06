global using eCommerce_backend.Dtos.Cinema;

namespace eCommerce_backend.Services.CinemaService
{
    public interface ICinemaService
    {
        Task<ServiceResponse<List<GetCinemasDto>>> GetAllCinemas();
        Task<ServiceResponse<GetCinemasDto>> GetCinemaById(int id);
        Task<ServiceResponse<List<GetCinemasDto>>> AddCinema(AddCinemaDto cinema);
        Task<ServiceResponse<GetCinemasDto>> UpdateCinema(UpdateCinemaDto cinema);
        Task<ServiceResponse<List<GetCinemasDto>>> DeleteCinema(int id);
    }
}
