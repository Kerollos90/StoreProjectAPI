using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Data.Contexts;
using Store.Data.Entites.identityAppUser;
using Store.Repository;
using Store.Repository.SeedData;

namespace Store.Web.Helper
{
    public class ApplySeedMethod
    {
        public static async Task ApplySeedData(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var logger = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = services.GetRequiredService<StoreDbContext>();

                    var userManger = services.GetRequiredService<UserManager<AppUser>>();

                    await context.Database.MigrateAsync();

                    await StoreSeedData.Seeddata(context, logger);

                    await StoreIdentityContextSeed.SeedUserAsync(userManger);




                }
                catch (Exception ex)
                {
                    var log = logger.CreateLogger<ApplySeedMethod>();

                    log.LogError(ex.Message);


                }



            }



        }





    }
}
