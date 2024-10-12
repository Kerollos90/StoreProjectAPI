using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using Store.Repository.Baskets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repository.Baskets
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;

        public BasketRepository(IConnectionMultiplexer redis) 
        {
            _database = redis.GetDatabase();
        
        }
        public async Task<bool> DeleteBasketAsync(string id)
         => await _database.KeyDeleteAsync(id);


        public async Task<CustomerBasket> GetBasketAsync(string id)
        {
            var data = await _database.StringGetAsync(id);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);

            
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
          var data =   await _database.StringSetAsync(basket.Id , JsonSerializer.Serialize(basket) ,TimeSpan.FromDays(30));

            return data ? await GetBasketAsync(basket.Id) : null ;
        }
    }
}
