using Renato.ECommerce.Domain.DTOs;
using Renato.ECommerce.Domain.Enums;
using Renato.ECommerce.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Renato.ECommerce.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        // ---- Start code Listing 3.8 ----
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsFeatured { get; set; }

        public DiscountedProduct ApplyDiscountFor(IUserContext user)
        {
            bool preferred = user.IsInRole(Role.PreferredCustomer);

            decimal discount = preferred ? .95m : 1.00m;

            return new DiscountedProduct(name: this.Name, unitPrice: this.UnitPrice * discount);
        }
    }
}
