using AutoMapper;
using Web.Api.Domain;
using Web.Api.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.ModelMappers.OrderMappers
{
    public class OrderDtoAutoMapperProfile : Profile
    {
        public OrderDtoAutoMapperProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        }
    }
}
