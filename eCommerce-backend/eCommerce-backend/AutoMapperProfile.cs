global using AutoMapper;
using eCommerce_backend.Dtos.Actor;
using eCommerce_backend.Dtos.MovieDto;
using eCommerce_backend.Models;
using System.Linq;

namespace eCommerce_backend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Actor, GetActorsDto>().ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies!.Select(m => m.Id).ToList()));
            CreateMap<AddActorDto, Actor>().ForMember(dest => dest.Movies, opt => opt.Ignore());
            CreateMap<Producer, GetProducersDto>().ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies!.Select(m => m.Id).ToList()));
            CreateMap<AddProducerDto, Producer>().ForMember(dest => dest.Movies, opt => opt.Ignore());
            CreateMap<Cinema, GetCinemasDto>().ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies!.Select(m => m.Id).ToList()));
            CreateMap<AddCinemaDto, Cinema>().ForMember(dest => dest.Movies, opt => opt.Ignore());
            CreateMap<Movie,GetMoviesDto>().ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors!.Select(a => a.Id).ToList()));
            CreateMap<AddMovieDto, Movie>().ForMember(dest => dest.Actors, opt => opt.Ignore());

            CreateMap<Movie, int>().ConvertUsing(m => m.Id);
        }
    }
}
