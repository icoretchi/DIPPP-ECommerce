using Renato.ECommerce.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Renato.ECommerce.WebUI.Models
{
    public class ProductViewModel
    {
        private static readonly CultureInfo PriceCulture = new CultureInfo("en-US");

        public ProductViewModel(DiscountedProduct product)
        {
            this.Name = product.Name;
            this.UnitPrice = product.UnitPrice;
        }

        public string Name { get; }
        public decimal UnitPrice { get; }
        public string SummaryText => string.Format(PriceCulture, "{0} ({1:C})", Name, UnitPrice);
    }
}
