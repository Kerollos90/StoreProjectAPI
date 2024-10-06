using Store.Repository.Baskets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.BasketServices.Dtos
{
    public class CustomerBasketDto
    {
        public string? Id { get; set; }

        public int? DeliveryMethodId { get; set; }

        public decimal ShippingPrice { get; set; }


        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();



    }
}
