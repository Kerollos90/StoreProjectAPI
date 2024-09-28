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

            orderAsc(p => p.Id);

            if (!string.IsNullOrEmpty(spec.Sort))
            {
                switch (spec.Sort)
                {
                    case "Price":
                        orderAsc(x => x.Price);
                        break;

                    case "namedesc":
                        orderDesc(x => x.Name);
                        break;


                    case "iddesc":
                        orderDesc(x => x.Id);
                        break;

                        default:
                        orderAsc(x => x.Id);
                        
                        
                        break;





                }




            }


        }

        public ProductSpecification(int? id) : base(x=>x.Id == id)         
        {

            AddIncludes(p => p.Brand);
            AddIncludes(p => p.Type);
        }





    }


}
