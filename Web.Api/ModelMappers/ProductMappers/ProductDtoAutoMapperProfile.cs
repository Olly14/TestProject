using AutoMapper;
using Web.Api.Domain;
using Web.Api.DtoModels;

namespace Web.Api.ModelMappers.ProductMappers
{
    public class ProductDtoAutoMapperProfile : Profile
    {
        public ProductDtoAutoMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
