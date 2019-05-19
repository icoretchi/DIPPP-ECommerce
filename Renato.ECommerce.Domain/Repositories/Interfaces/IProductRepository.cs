using Renato.ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Renato.ECommerce.Domain.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetFeaturedProducts();
    }
}
