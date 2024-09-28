using Microsoft.EntityFrameworkCore;
using Store.Data.Contexts;
using Store.Data.Entites;
using Store.Repository.Interfaces;
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
        
    }
}
