using AutoMapper;
using Store.Repository.Baskets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.BasketServices.Dtos
{
    public class BasketProfile : Profile
    {



        public BasketProfile() 
        {
            CreateMap<BasketItemDto, BasketItem>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>().ReverseMap();
            


        }



    }
}
