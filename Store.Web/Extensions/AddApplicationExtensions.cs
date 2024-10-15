using Microsoft.AspNetCore.Mvc;
using Store.Data.Contexts;
using Store.Repository.Interfaces;
using Store.Repository.Repositories;
using Store.Service.Services.Products.Dtos;
using Store.Service.Services.Products;
using Store.Service.HandleResponse;
using Store.Service.CacheServices;
using Store.Service.BasketServices;
using Store.Repository.Baskets;
using Store.Service.BasketServices.Dtos;
using Store.Service.Services.TokenServices;
using Store.Service.Services.UserServices;

namespace Store.Web.Extensions
{
    public static class  AddApplicationExtensions

    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
         

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductSevice, ProductService>();
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(BasketProfile));




            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = ActionContext =>
                {
                    var error = ActionContext.ModelState
                                             .Where(model => model.Value?.Errors.Count > 0)
                                             .SelectMany(model => model.Value?.Errors)
                                             .Select(error => error.ErrorMessage)
                                             .ToList();

                    var errorResponse = new ValidationErrorsResponse
                    {
                        Errors = error

                    };

                    return new BadRequestObjectResult(errorResponse);



                };




            });



            return (services);
            
        }

    }
}
