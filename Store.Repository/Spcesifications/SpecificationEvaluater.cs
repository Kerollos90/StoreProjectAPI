using Microsoft.EntityFrameworkCore;
using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Spcesifications
{
    public class SpecificationEvaluater<TEntity , TKey> where TEntity : BaseEntity<TKey>
    {

        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery , ISpecification<TEntity> specs)
        {
            var query = inputQuery;

            if (specs.Criteria != null)
                query = query.Where(specs.Criteria);

            query = specs.Includes.Aggregate(query, (current, includeExpression) => current.Include(includeExpression));


            return query;
        
        
        }

        
    }
}
