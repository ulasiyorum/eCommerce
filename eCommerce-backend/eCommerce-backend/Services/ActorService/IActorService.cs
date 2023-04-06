namespace eCommerce_backend.Services.ActorService
{
    public interface IActorService
    {
        Task<ServiceResponse<List<GetActorsDto>>> GetAllActors();
        Task<ServiceResponse<GetActorsDto>> GetActorById(int id);
        Task<ServiceResponse<List<GetActorsDto>>> AddActor(AddActorDto actor);
        Task<ServiceResponse<GetActorsDto>> UpdateActor(UpdateActorDto actor);
        Task<ServiceResponse<List<GetActorsDto>>> DeleteActor(int id);
    }
}
