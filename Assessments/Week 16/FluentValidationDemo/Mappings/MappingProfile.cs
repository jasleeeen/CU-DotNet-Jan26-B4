using AutoMapper;
using FluentValidationDemo.DTOs;
using FluentValidationDemo.Models;

namespace FluentValidationDemo.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOrderDTO, Order>();
            CreateMap<Order, OrderResponseDTO>();
        }
    }
}
