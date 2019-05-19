using Renato.ECommerce.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Renato.ECommerce.Domain.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<DiscountedProduct> GetFeaturedProducts();
    }
}
