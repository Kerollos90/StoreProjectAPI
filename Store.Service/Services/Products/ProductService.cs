using AutoMapper;
using Store.Data.Entites;
using Store.Repository.Interfaces;
using Store.Repository.Spcesifications.ProductSpecifications;
using Store.Service.Helper;
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

        public async Task<PaginatedResultDto<ProductDetailsDto>> GetAllProductsAsync(BaseProductSpecif specif)
        {
            var specs = new ProductSpecification(specif);

            var products = await _unitOfWork.Repository<Store.Data.Entites.Product,int>().GetAllWithSpcificationAsync(specs);

            var countinput = new CountPaginated(specif);

            var count = await _unitOfWork.Repository<Product, int>().GetCountSpcificationAsync(countinput);

            var mapped = _mapper.Map<IReadOnlyList<ProductDetailsDto>>(products);



            return new PaginatedResultDto<ProductDetailsDto>(specif.pageindex,specif.pagesize , count ,mapped);


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

            var specs = new ProductSpecification(id);

            var product = await _unitOfWork.Repository<Product,int>().GetWithSpcificationById(specs);

            if (product is null)
                throw new Exception("Product Not Found");

            var mapped = _mapper.Map<ProductDetailsDto>(product);


            return mapped;

        }
    }
}
