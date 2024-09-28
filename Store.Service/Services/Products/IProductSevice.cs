using Store.Repository.Spcesifications.ProductSpecifications;

namespace Store.Service.Services.Products.Dtos
{
    public interface IProductSevice
    {

        Task<ProductDetailsDto> GetProductByIdAsync(int? id);

        Task<IReadOnlyList<ProductDetailsDto>> GetAllProductsAsync(BaseProductSpecif specif);
        Task<IReadOnlyList<BrandTypesDtos>> GetAllBrandsAsync();
        Task<IReadOnlyList<BrandTypesDtos>> GetAllTypesAsync();

       



    }
}
