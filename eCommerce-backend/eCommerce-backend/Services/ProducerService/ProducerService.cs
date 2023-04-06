namespace eCommerce_backend.Services.ProducerService
{
    public class ProducerService : IProducerService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public ProducerService(IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<ServiceResponse<List<GetProducersDto>>> AddProducer(AddProducerDto producer)
        {
            var response = new ServiceResponse<List<GetProducersDto>>();
            try
            {
                var _producer = mapper.Map<Producer>(producer);
                context.Producers.Add(_producer);
                await context.SaveChangesAsync();
                response.Data = await context.Producers.Select(p => mapper.Map<GetProducersDto>(p)).ToListAsync();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetProducersDto>>> DeleteProducer(int id)
        {
            var response = new ServiceResponse<List<GetProducersDto>>();
            try
            {
                var producer = await context.Producers.FirstOrDefaultAsync(p => p.Id == id);

                if (producer is null)
                    throw new Exception("Producer with Id:" + id + " is not found");

                context.Producers.Remove(producer);
                await context.SaveChangesAsync();

                response.Data = await context.Producers.Select(p => mapper.Map<GetProducersDto>(p)).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetProducersDto>>> GetAllProdcucers()
        {
            var response = new ServiceResponse<List<GetProducersDto>>();
            try
            {
                var producers = await context.Producers.ToListAsync();

                response.Data = producers.Select(p => mapper.Map<GetProducersDto>(p)).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetProducersDto>> GetProducerById(int id)
        {
            var response = new ServiceResponse<GetProducersDto>();
            try
            {
                var producer = await context.Producers.FirstOrDefaultAsync(p => p.Id == id);

                if (producer is null)
                    throw new Exception("Producer with Id:" + id + " is not found");

                response.Data = mapper.Map<GetProducersDto>(producer);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetProducersDto>> UpdateProducer(UpdateProducerDto producer)
        {
            var response = new ServiceResponse<GetProducersDto>();
            try
            {
                var _producer = await context.Producers.FirstOrDefaultAsync(p => p.Id == producer.Id);

                if (_producer is null)
                    throw new Exception("Producer with Id:" + producer.Id + " is not found");

                _producer.ProfilePictureURL = producer.ProfilePictureURL;
                _producer.Name = producer.Name;
                _producer.Movies = producer.Movies;
                _producer.Bio = producer.Bio;

                await context.SaveChangesAsync();
                response.Data = mapper.Map<GetProducersDto>(_producer);
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
