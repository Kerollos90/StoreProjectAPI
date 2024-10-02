using Azure.Core.Serialization;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Service.CacheServices
{
    public class CacheService : ICacheService
    {

        private readonly IDatabase _database;

        public CacheService(IConnectionMultiplexer redis )
        {
            _database = redis.GetDatabase();
            
        }



        public async Task<string> GetCacheKey(string cacheKey)
        {
            var get =await _database.StringGetAsync(cacheKey);

            if (get.IsNullOrEmpty)
                return null;

            return get.ToString();



            
        }

        public async Task SetCacheKey(string cacheKey, object Response, TimeSpan timeInLive)
        {
            if(cacheKey == null)
                return;

            var option = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                

            var optionSerialed = JsonSerializer.Serialize(Response , option);

             await _database.StringSetAsync(cacheKey, optionSerialed, timeInLive);
            
        }
    }
}
