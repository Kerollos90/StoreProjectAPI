﻿using AutoMapper;
using Store.Data.Entites;
using Store.Repository.Interfaces;
using Store.Repository.Spcesifications.ProductSpecifications;
using Store.Service.Services.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Products
{
    public class ProductService : IProductSevice
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<BrandTypesDtos>> GetAllBrandsAsync()
        { 
            var brands = await _unitOfWork.Repository<ProductBrand,int>().GetAllAsNoTrackingAsync();

            var mappedbrands = _mapper.Map<IReadOnlyList<BrandTypesDtos>>(brands);

            return mappedbrands;
        
        }

        public async Task<IReadOnlyList<ProductDetailsDto>> GetAllProductsAsync(BaseProductSpecif specif)
        {
            var specs = new ProductSpecification(specif);

            var products = await _unitOfWork.Repository<Store.Data.Entites.Product,int>().GetAllWithSpcificationAsync(specs);

            var mapped = _mapper.Map<IReadOnlyList<ProductDetailsDto>>(products);



            return mapped;


        }

        public async Task<IReadOnlyList<BrandTypesDtos>> GetAllTypesAsync()
        {
            var Types = await _unitOfWork.Repository<ProductType, int>().GetAllAsync();

            var mapped = _mapper.Map<IReadOnlyList<BrandTypesDtos>>(Types);


            return mapped;




        }

        public async Task<ProductDetailsDto> GetProductByIdAsync(int? id)
        {
            if(id is null)
                throw new ArgumentNullException(nameof(id));

            var product = await _unitOfWork.Repository<Product,int>().GetById(id.Value);

            var mapped = _mapper.Map<ProductDetailsDto>(product);


            return mapped;

        }
    }
}
