using AutoMapper;
using MoviesAPI.DTOs;
using MoviesAPI.Entidades;

namespace MoviesAPI.Helder
{
    public class AutoMaperProfiler:Profile
    {
        public AutoMaperProfiler()
        {
            CreateMap<Genero, GeneroDTO>().ReverseMap();
            CreateMap<GeneroCreacionDTO, Genero>();
            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<AutorCreacionDTO, Actor>();

        }
    }
}
