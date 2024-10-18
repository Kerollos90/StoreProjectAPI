using Store.Data.Entites;
using Store.Service.Services.OrderServices.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.OrderServices
{
    public interface IOrderService
    {
        Task<OrderDetailsDto> CreateOrderAsync(OrderDto input);
        Task<OrderDetailsDto> GetOrderByIdAsync(Guid id);
        Task<IReadOnlyList<OrderDetailsDto>> GetAllOrderFromUserAsync(string buyerEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetAllDeliveryMethodAsync();


    }
}
