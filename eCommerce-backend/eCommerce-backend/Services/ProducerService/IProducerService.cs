global using eCommerce_backend.Dtos.Producer;

namespace eCommerce_backend.Services.ProducerService
{
    public interface IProducerService
    {
        Task<ServiceResponse<List<GetProducersDto>>> GetAllProdcucers();
        Task<ServiceResponse<GetProducersDto>> GetProducerById(int id);
        Task<ServiceResponse<List<GetProducersDto>>> AddProducer(AddProducerDto producer);
        Task<ServiceResponse<GetProducersDto>> UpdateProducer(UpdateProducerDto producer);
        Task<ServiceResponse<List<GetProducersDto>>> DeleteProducer(int id);

    }
}
