using AutoMapper;
using Web.Api.Domain;
using Web.Api.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.ModelMappers.DropDownListsMappers
{
    public class DropDownListsDtoAutoMapperProfile : Profile
    {
        public DropDownListsDtoAutoMapperProfile()
        {
            CreateMap<Gender, GenderDto>().ReverseMap();
        }
    }
}
