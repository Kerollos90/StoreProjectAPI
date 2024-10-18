using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.CacheServices
{
    public interface ICacheService
    {

        Task<string> GetCacheKey(string cacheKey);

        Task SetCacheKey(string cacheKey, object Response, TimeSpan timeInLive);


    }
}
