global using AutoMapper;
using eCommerce_backend.Dtos.Actor;
using eCommerce_backend.Models;

namespace eCommerce_backend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Actor, GetActorsDto>();
            CreateMap<AddActorDto, Actor>();
            CreateMap<Producer, GetProducersDto>();
            CreateMap<AddProducerDto, Producer>();
            CreateMap<Cinema, GetCinemasDto>();
            CreateMap<AddCinemaDto, Cinema>();
        }
    }
}
