using Store.Data.Entites.OrederEntites;
using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.OrderServices.OrderDtos
{
    public class OrderDetailsDto
    {
        public Guid Id { get; set; }

        public string BuyerEmail { get; set; }

        public DateTimeOffset DateTimeOffset { get; set; } 

        public ShippingAddressDto ShippingAddress { get; set; }

        public string DeliveryMethodName { get; set; }       

        public OrderStatus OrderStatus { get; set; } 

        public OrderPaymentStatus OrderPayment { get; set; } 

        public IReadOnlyList<OrderItemDto> OrderItems { get; set; }

        public string SubTotal { get; set; }

        public decimal ShippingPrice { get; set; }

        public decimal Total { get; set; }


        public string? BasketId { get; set; }


    }
}
