using Store.Data.Entites;
using Store.Repository.Spcesifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface IGenericRepository<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {

        Task<TEntity> GetById(TKey? Id);

        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<IReadOnlyList<TEntity>> GetAllAsNoTrackingAsync();

        Task<IReadOnlyList<TEntity>> GetAllWithSpcificationAsync();

        Task<TEntity> GetWithSpcificationById(ISpecification<TEntity> specs);


        Task Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);





    }
}
