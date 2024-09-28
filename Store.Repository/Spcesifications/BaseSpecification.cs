using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Spcesifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification( Expression<Func<T , bool>> criteria) 
        {
            Criteria = criteria;
        
        
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();


        public Expression<Func<T, object>> orderby { get;private set; }
        public Expression<Func<T, object>> orderbyDesc { get;private set; }


        protected void AddIncludes(Expression<Func<T, object>> includeExpression)
            => Includes.Add(includeExpression);



        protected void orderAsc(Expression<Func<T, object>> order)
            => orderby = order;
        protected void orderDesc(Expression<Func<T, object>> order)
            => orderbyDesc = order;


    }
}
