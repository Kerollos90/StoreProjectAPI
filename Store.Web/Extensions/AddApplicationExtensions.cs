using Microsoft.AspNetCore.Mvc;
using Store.Data.Contexts;
using Store.Repository.Interfaces;
using Store.Repository.Repositories;
using Store.Service.Services.Products.Dtos;
using Store.Service.Services.Products;
using Store.Service.HandleResponse;

namespace Store.Web.Extensions
{
    public static class  AddApplicationExtensions

    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
         

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductSevice, ProductService>();
            services.AddAutoMapper(typeof(ProductProfile));

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
