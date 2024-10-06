using Microsoft.AspNetCore.Identity;
using Store.Data.Contexts;
using Store.Data.Entites.identityAppUser;
using System.Runtime.CompilerServices;

namespace Store.Web.Extensions
{
    public static class AddIdentityApplicationExtensions
    {

        public static IServiceCollection AddIdentityApplicationServices(this IServiceCollection services)
        {
           var  builder = services.AddIdentityCore<AppUser>();

            builder = new IdentityBuilder(builder.UserType , builder.Services);

            builder.AddEntityFrameworkStores<StoreIdentityDbContext>();

            builder.AddSignInManager<SignInManager<AppUser>>();


            services.AddAuthentication();


            return services;
        
        }


    }
}
