using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Store.Data.Contexts;
using Store.Data.Entites.identityAppUser;
using System.Runtime.CompilerServices;
using System.Text;

namespace Store.Web.Extensions
{
    public static class AddIdentityApplicationExtensions
    {

        public static IServiceCollection AddIdentityApplicationServices(this IServiceCollection services , IConfiguration _config)
        {
           var  builder = services.AddIdentityCore<AppUser>();

            builder = new IdentityBuilder(builder.UserType , builder.Services);

            builder.AddEntityFrameworkStores<StoreIdentityDbContext>();

            builder.AddSignInManager<SignInManager<AppUser>>();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option => 
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token : Key"])),
                        ValidateIssuer = true,
                        ValidIssuer = _config["Token:Issure"],
                        ValidateAudience = false

                    };
                
                
                });


            return services;
        
        }


    }
}
