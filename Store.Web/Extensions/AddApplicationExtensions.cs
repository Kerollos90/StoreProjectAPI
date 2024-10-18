using Microsoft.AspNetCore.Mvc;
using Store.Data.Contexts;
using Store.Repository.Interfaces;
using Store.Repository.Repositories;
using Store.Service.Services.Products.Dtos;
using Store.Service.Services.Products;
using Store.Service.HandleResponse;
using Store.Repository.Baskets;
using Store.Service.Services.TokenServices;
using Store.Service.Services.UserServices;
using Store.Service.Services.CacheServices;
using Store.Service.Services.BasketServices;
using Store.Service.Services.BasketServices.Dtos;
using Store.Service.Services.OrderServices;
using Store.Service.Services.OrderServices.OrderDtos;

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
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(BasketProfile));
            services.AddAutoMapper(typeof(OrderProfile));




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
