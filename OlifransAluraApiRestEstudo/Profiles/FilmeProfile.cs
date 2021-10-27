using AutoMapper;
using OlifransAluraApiRestEstudo.Data.Dtos;
using OlifransAluraApiRestEstudo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
