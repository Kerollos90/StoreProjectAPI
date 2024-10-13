using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Expressions;
using Store.Repository.Spcesifications.ProductSpecifications;
using Store.Service.Services.Products.Dtos;
using Store.Web.Helper;

namespace Store.Web.Controllers
{
    [Authorize]
    public class ProductController : BaseController
    {
        private readonly IProductSevice _productSevice;

        public ProductController(IProductSevice productSevice)
        {
            _productSevice = productSevice;
        }
        [HttpGet]
        
        public async Task<ActionResult<IReadOnlyList<BrandTypesDtos>>> GetAllBrandsAsync()
           => Ok(await _productSevice.GetAllBrandsAsync());
        [HttpGet]
        [CacheLiveTimeInSerever(20)]
        
        public async Task<ActionResult<IReadOnlyList<ProductDetailsDto>>> GetAllProductsAsync([FromQuery]BaseProductSpecif specif)
         => Ok(await _productSevice.GetAllProductsAsync( specif));
        [HttpGet]

        public async Task<ActionResult< IReadOnlyList<BrandTypesDtos>>> GetAllTypesAsync()
         => Ok (await _productSevice.GetAllTypesAsync());

        [HttpGet]
        
        public async Task<ActionResult< ProductDetailsDto>> GetProductByIdAsync(int? id)
        => Ok(await _productSevice.GetProductByIdAsync(id));
    }
}
