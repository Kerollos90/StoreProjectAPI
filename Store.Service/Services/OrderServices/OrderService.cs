using Store.Data.Entites;
using Store.Service.Services.OrderServices.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        public Task<OrderDetailsDto> CreateOrderAsync(OrderDto input)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetAllDeliveryMethodAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<OrderDetailsDto>> GetAllOrderFromUserAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetailsDto> GetOrderByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
