using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.Data.Contexts;
using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repository.SeedData
{
    public class StoreSeedData
    {
        public static async Task Seeddata(StoreDbContext context, ILoggerFactory factory)
        {

            try
            {






                if (context.ProductBrands != null && !context.ProductBrands.Any())
                {
                    var brandsdata = File.ReadAllText("../Store.Repository/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsdata);

                    if (brands is not null)
                        await context.ProductBrands.AddRangeAsync(brands);


                }

                if (context.ProductTypes != null && !context.ProductTypes.Any())
                {
                    var typesdata = File.ReadAllText("../Store.Repository/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesdata);

                    if (types is not null)
                        await context.ProductTypes.AddRangeAsync(types);


                }

                if (context.DeliveryMethods != null && !context.DeliveryMethods.Any())
                {
                    var deliverymethod = File.ReadAllText("../Store.Repository/SeedData/delivery.json");

                    var deliveries = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliverymethod);

                    if (deliveries is not null)
                        await context.DeliveryMethods.AddRangeAsync(deliveries);


                }


                if (context.Products != null && !context.Products.Any())
                {
                    var productsdata = File.ReadAllText("../Store.Repository/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsdata);

                    if (products is not null)
                        await context.Products.AddRangeAsync(products);


                }


                await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                var logger = factory.CreateLogger<StoreSeedData>();

                logger.LogError(ex.Message);



            }
        }



    }
}
