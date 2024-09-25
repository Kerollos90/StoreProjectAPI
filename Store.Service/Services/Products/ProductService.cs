using Store.Data.Entites;
using Store.Repository.Interfaces;
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

        public ProductService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IReadOnlyList<ProductDetailsDto>> GetAllBrandsAsync()
        { 
            var brands = await _unitOfWork.Repository<ProductBrand,int>().GetAllAsNoTrackingAsync();

            IReadOnlyList<ProductDetailsDto> mappedbrands = brands.Select(x => new ProductDetailsDto
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt



            }).ToList();

            return mappedbrands;
        
        }

        public async Task<IReadOnlyList<ProductDetailsDto>> GetAllProductsAsync()
        {

            var products = await _unitOfWork.Repository<Store.Data.Entites.Product,int>().GetAllAsync();

            var mapped = products.Select(x=>new ProductDetailsDto 
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                Description = x.Description,    

                BrandName=x.Brand.Name,
                TypeName=x.Type.Name,
                Price=x.Price,
                PictureUrl=x.PictureUrl


            
            }).ToList();

            return mapped;


        }

        public async Task<IReadOnlyList<ProductDetailsDto>> GetAllTypesAsync()
        {
            var Types = await _unitOfWork.Repository<ProductType, int>().GetAllAsync();

            var mappedbrands = Types.Select(x => new ProductDetailsDto
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt



            }).ToList();

            return mappedbrands;




        }

        public async Task<ProductDetailsDto> GetProductByIdAsync(int? id)
        {
            if(id is null)
                throw new ArgumentNullException(nameof(id));

            var product = await _unitOfWork.Repository<Product,int>().GetById(id.Value);

            var mapped =  new ProductDetailsDto
            {
                Id = product.Id,
                Name = product.Name,
                CreatedAt = product.CreatedAt,
                Description = product.Description,

                BrandName = product.Brand.Name,
                TypeName = product.Type.Name,
                Price = product.Price,
                PictureUrl = product.PictureUrl



            };

            return mapped;

        }
    }
}
