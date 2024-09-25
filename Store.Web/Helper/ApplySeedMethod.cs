using Microsoft.EntityFrameworkCore;
using Store.Data.Contexts;
using Store.Repository;

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

                    await context.Database.MigrateAsync();

                    await StoreSeedData.Seeddata(context, logger);




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
