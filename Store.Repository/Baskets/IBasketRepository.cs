using Store.Repository.Baskets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Baskets
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string id);

        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
        
        Task<bool> DeleteBasketAsync(string id);

    }
}
