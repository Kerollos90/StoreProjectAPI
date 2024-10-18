﻿using Store.Data.Entites.OrederEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.OrderServices.OrderDtos
{
    public class OrderItemDto
    {
        
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string PictureURL { get; set; }

        public Guid OrderId { get; set; }


    }
}
