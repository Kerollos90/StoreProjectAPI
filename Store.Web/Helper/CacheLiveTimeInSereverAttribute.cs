using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Store.Service.CacheServices;
using System.Text;

namespace Store.Web.Helper
{
    public class CacheLiveTimeInSereverAttribute : Attribute , IAsyncActionFilter
    {
        private readonly int _liveTimeInSecond;

        public CacheLiveTimeInSereverAttribute(int liveTimeInSecond)
        {
            _liveTimeInSecond = liveTimeInSecond;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();

            var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);

            var cacheResponse = await cacheService.GetCacheKey(cacheKey);

            if (!string.IsNullOrEmpty(cacheResponse))
            {
                var cache = new ContentResult
                {

                    Content = cacheResponse,
                    ContentType = "application/json",
                    StatusCode = 200




                };

                context.Result = cache;

                return;
            }


            var response = await next();


            if (response.Result is OkObjectResult result)
              await cacheService.SetCacheKey(cacheKey, result.Value, TimeSpan.FromSeconds(_liveTimeInSecond));


            

            
         }



     


        public string GenerateCacheKeyFromRequest(HttpRequest request)
        { 
            StringBuilder cacheKey = new StringBuilder();

            cacheKey.Append($"{request.Path}");

            foreach (var (key , value) in request.Query.OrderBy(x=>x.Key))           
                cacheKey.Append($"{key}-{value}");

            return cacheKey.ToString(); 



            
            
            


        
        
        
        }
    }


}
