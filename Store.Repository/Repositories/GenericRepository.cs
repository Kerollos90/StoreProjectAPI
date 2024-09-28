using Microsoft.EntityFrameworkCore;
using Store.Data.Contexts;
using Store.Data.Entites;
using Store.Repository.Interfaces;
using Store.Repository.Spcesifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext _dbContext;

        public GenericRepository(StoreDbContext dbContext) 
        {
            _dbContext = dbContext;
        }


        public async Task Add(TEntity entity)
        =>await _dbContext.Set<TEntity>().AddAsync(entity);

        public void Delete(TEntity entity)
        => _dbContext.Set<TEntity>().Remove(entity);

       
        public async Task<IReadOnlyList<TEntity>> GetAllAsNoTrackingAsync()
            => await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
            => await _dbContext.Set<TEntity>().ToListAsync();


        public async Task<TEntity> GetById(TKey? Id)
            => await _dbContext.Set<TEntity>().FindAsync(Id);


        public  void Update(TEntity entity)
            =>  _dbContext.Set<TEntity>().Update(entity);

        public async Task<TEntity> GetWithSpcificationById(ISpecification<TEntity> specs)
           => await ApplSpecification(specs).FirstOrDefaultAsync();


        public async Task<IReadOnlyList<TEntity>> GetAllWithSpcificationAsync(ISpecification<TEntity> specs)
            => await ApplSpecification(specs).ToListAsync() ;



        private IQueryable<TEntity> ApplSpecification(ISpecification<TEntity> specs)
           => SpecificationEvaluater<TEntity, TKey>.GetQuery(_dbContext.Set<TEntity>(), specs);

            

                




        
    }
}
