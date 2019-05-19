using System;
using System.Collections.Generic;
using System.Text;

namespace Renato.ECommerce.Domain.DTOs
{
    public class DiscountedProduct
    {
        public DiscountedProduct(string name, decimal unitPrice)
        {
            this.Name = name ?? throw new ArgumentNullException("name");
            this.UnitPrice = unitPrice;
        }

        public string Name { get; }
        public decimal UnitPrice { get; }
    }
}
