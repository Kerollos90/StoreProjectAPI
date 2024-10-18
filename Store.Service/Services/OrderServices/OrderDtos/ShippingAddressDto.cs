﻿using System.ComponentModel.DataAnnotations;

namespace Store.Service.Services.OrderServices.OrderDtos
{
    public class ShippingAddressDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string Street { get; set; }
        [Required]

        public string City { get; set; }
        [Required]

        public string State { get; set; }
        [Required]

        public string PostalCode { get; set; }

    }
}