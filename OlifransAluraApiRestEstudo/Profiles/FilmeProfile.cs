using AutoMapper;
using OlifransAluraApiRestEstudo.Data.Dtos;
using OlifransAluraApiRestEstudo.Models;

namespace OlifransAluraApiRestEstudo.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFimeDto, Filme>();
            CreateMap<Filme, ReadmeFimeDto>();
            CreateMap<UpdateFimeDto, Filme>();
        }
    }
}