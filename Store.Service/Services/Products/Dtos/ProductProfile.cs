using AutoMapper;
using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Products.Dtos
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, ProductDetailsDto>().ForMember(d=>d.BrandName,o=>o.MapFrom(s=>s.Brand.Name))
            .ForMember(d=>d.TypeName,o=>o.MapFrom(s=>s.Type.Name));


            CreateMap<ProductBrand, BrandTypesDtos>();
            CreateMap<ProductType, BrandTypesDtos>();
        
        }
        


    }
}
