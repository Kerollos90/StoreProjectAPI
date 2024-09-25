
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using Store.Data.Contexts;
using Store.Repository;
using Store.Repository.Interfaces;
using Store.Service.Services.Products.Dtos;
using Store.Web.Helper;

namespace Store.Web
{
    public class Program
    {
        
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<StoreDbContext>(o =>
                {
                    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                });

            builder.Services.AddScoped<IUnitOfWork, IUnitOfWork>();
            builder.Services.AddAutoMapper(typeof(ProductProfile));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

           await ApplySeedMethod.ApplySeedData(app);


                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
