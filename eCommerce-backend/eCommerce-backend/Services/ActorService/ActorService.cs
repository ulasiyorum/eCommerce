using Microsoft.AspNetCore.SignalR;

namespace eCommerce_backend.Services.ActorService
{
    public class ActorService : IActorService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public ActorService(IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<ServiceResponse<List<GetActorsDto>>> AddActor(AddActorDto actor)
        {
            var response = new ServiceResponse<List<GetActorsDto>>();
            var _actor = mapper.Map<Actor>(actor);
            context.Actors.Add(_actor);
            await context.SaveChangesAsync();
            response.Data = await context.Actors.Select(a => mapper.Map<GetActorsDto>(a)).ToListAsync();
            return response;

        }

        public async Task<ServiceResponse<List<GetActorsDto>>> DeleteActor(int id)
        {
            var response = new ServiceResponse<List<GetActorsDto>>();

            try
            {
                var actor = await context.Actors.FirstOrDefaultAsync(a => a.Id == id);

                if (actor is null)
                    throw new Exception("Actor with Id:" + id + " is not found");

                context.Actors.Remove(actor);
                await context.SaveChangesAsync();

                response.Data = await context.Actors.Select(a => mapper.Map<GetActorsDto>(a)).ToListAsync();
            } 
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message; 
            }

            return response;
        }

        public async Task<ServiceResponse<GetActorsDto>> GetActorById(int id)
        {
            var response = new ServiceResponse<GetActorsDto>();
            try
            {
                var actor = await context.Actors.FirstOrDefaultAsync(a => a.Id == id);

                if (actor is null)
                    throw new Exception("Actor with Id:" + id + " is not found");

                response.Data = mapper.Map<GetActorsDto>(actor);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetActorsDto>>> GetAllActors()
        {
            var response = new ServiceResponse<List<GetActorsDto>>();
            try
            {
                var actors = await context.Actors.ToListAsync();
                
                response.Data = actors.Select(a => mapper.Map<GetActorsDto>(a)).ToList();

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetActorsDto>> UpdateActor(UpdateActorDto actor)
        {
            var response = new ServiceResponse<GetActorsDto>();
            try
            {
                var _actor = await context.Actors.FirstOrDefaultAsync(c => c.Id == actor.Id);

                if (_actor is null)
                    throw new Exception("Actor with Id:" + actor.Id + " is not found");

                _actor.Name = actor.Name;
                _actor.ProfilePictureURL = actor.ProfilePictureURL;
                _actor.Bio = actor.Bio;
                _actor.Actors_Movies = actor.Actors_Movies;

                await context.SaveChangesAsync();
                response.Data = mapper.Map<GetActorsDto>(_actor);
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
