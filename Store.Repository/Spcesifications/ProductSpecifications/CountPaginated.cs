using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Spcesifications.ProductSpecifications
{
    public class CountPaginated : BaseSpecification<Product>
    {
        public CountPaginated(BaseProductSpecif spec) : base
            (
               Product => (!spec.BrandId.HasValue || Product.BrandId == spec.BrandId.Value) &&
               (!spec.TypeId.HasValue || Product.TypeId == spec.TypeId.Value) &&
               (string.IsNullOrEmpty(spec.Search) || Product.Name.Trim().ToLower().Contains(spec.Search))
            )
        { 
        
        }
    }
}
