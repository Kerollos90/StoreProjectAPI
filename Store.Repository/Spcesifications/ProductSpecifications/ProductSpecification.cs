using Store.Data.Entites;
using Store.Repository.Spcesifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Spcesifications.ProductSpecifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(BaseProductSpecif spec) : base
            (
               Product => (!spec.BrandId.HasValue || Product.BrandId == spec.BrandId.Value) &&
               (!spec.TypeId.HasValue || Product.TypeId == spec.TypeId.Value)
            )
        {

            AddIncludes(p => p.Brand);
            AddIncludes(p => p.Type);


        }





    }
}
