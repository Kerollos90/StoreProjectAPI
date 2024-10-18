using AutoMapper;
using Store.Data.Entites.OrederEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.OrderServices.OrderDtos
{
    public class OrderProfile : Profile
    {
        public OrderProfile( ) 
        {
            CreateMap<ShippingAddress, ShippingAddressDto>().ReverseMap();

            CreateMap<Order, OrderDetailsDto >()
                .ForMember(des => des.ShippingPrice, act => act.MapFrom(x => x.DeliveryMethod.Price))
                .ForMember(des => des.DeliveryMethodName, act => act.MapFrom(x => x.DeliveryMethod.ShortName));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(des => des.ProductId, asc => asc.MapFrom(x => x.ProductItem.ProductId))
                .ForMember(des => des.ProductName, asc => asc.MapFrom(x => x.ProductItem.ProductName))
                .ForMember(des => des.PictureURL, asc => asc.MapFrom<OrderItemPictureUrlResolver>());
        
        
        
        }




    }
}
