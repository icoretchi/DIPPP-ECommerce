using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Renato.ECommerce.WebUI.Models
{
    public class FeaturedProductsViewModel
    {
        public FeaturedProductsViewModel(IEnumerable<ProductViewModel> products)
        {
            this.Products = products;
        }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
