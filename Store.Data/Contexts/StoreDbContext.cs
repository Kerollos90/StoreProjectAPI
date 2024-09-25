using Microsoft.EntityFrameworkCore;
using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Contexts
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }


        DbSet<Product> Products { get; set; }

        DbSet<ProductBrand> ProductBrands { get; set; }

        DbSet<ProductType> ProductTypes { get; set; }

    }
}
