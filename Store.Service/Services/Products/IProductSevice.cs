using Store.Repository.Spcesifications.ProductSpecifications;
using Store.Service.Helper;

namespace Store.Service.Services.Products.Dtos
{
    public interface IProductSevice
    {

        Task<ProductDetailsDto> GetProductByIdAsync(int? id);

        Task<PaginatedResultDto<ProductDetailsDto>> GetAllProductsAsync(BaseProductSpecif specif);
        Task<IReadOnlyList<BrandTypesDtos>> GetAllBrandsAsync();
        Task<IReadOnlyList<BrandTypesDtos>> GetAllTypesAsync();

       



    }
}
