using Store.Repository.Baskets.Models;
using Store.Service.BasketServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.BasketServices
{
    public interface IBasketService
    {
        Task<CustomerBasketDto> GetBasketAsync(string id);

        Task<CustomerBasketDto> UpdateBasketAsync(CustomerBasketDto basket);

        Task<bool> DeleteBasketAsync(string id);
    }
}
