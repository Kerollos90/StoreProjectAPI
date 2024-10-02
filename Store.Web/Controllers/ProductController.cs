﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Expressions;
using Store.Repository.Spcesifications.ProductSpecifications;
using Store.Service.Services.Products.Dtos;

namespace Store.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
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
