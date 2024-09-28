using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Spcesifications
{
    public interface ISpecification<T>
    {

        Expression<Func<T, bool>> Criteria { get; }

        List<Expression<Func<T, object>>> Includes { get; }

        public Expression<Func<T, object>> orderby { get; }
        public Expression<Func<T, object>> orderbyDesc { get;  }

    }
}
