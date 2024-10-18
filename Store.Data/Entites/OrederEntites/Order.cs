using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entites.OrederEntites
{
    public class Order : BaseEntity<Guid>
    {

        public string BuyerEmail { get; set; }

        public DateTimeOffset DateTimeOffset { get; set; } = DateTimeOffset.Now;

        public ShippingAddress ShippingAddress { get; set; }

        public DeliveryMethod DeliveryMethod { get; set; }

        public int? DeliveryMethodId { get; set; }

        public OrderStatus OrderStatus { get; set; } = OrderStatus.placed;

        public OrderPaymentStatus OrderPayment { get; set; } = OrderPaymentStatus.Pending;

        public IReadOnlyList<OrderItem> OrderItems { get; set; }

        public decimal SubTotal { get; set; }

        public decimal GetTotal()
            => SubTotal + DeliveryMethod.Price;
        public string? BasketId { get; set; }




    }
}
