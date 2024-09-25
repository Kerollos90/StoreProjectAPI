using Store.Data.Contexts;
using Store.Data.Entites;
using Store.Repository.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;

        private Hashtable _hashtable;


        public UnitOfWork(StoreDbContext context) 
        {
            _context = context;
        }
        public async Task<int>  Complite()
            => await _context.SaveChangesAsync();
      

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            if (_hashtable == null  )
             
                _hashtable = new Hashtable();
            

                var entity = typeof(TEntity).Name;

                if (!_hashtable.ContainsKey(entity))
                {

                    var entityType = typeof(GenericRepository<,>);

                    var instance = Activator.CreateInstance(entityType.MakeGenericType(typeof(TEntity),typeof(TKey)), _context);

                    _hashtable.Add(entity, instance);

                }

                return (IGenericRepository<TEntity, TKey>)_hashtable[entity];



            
            
            

            
        }
    }
}
