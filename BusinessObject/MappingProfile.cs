using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
        }
    }
}
