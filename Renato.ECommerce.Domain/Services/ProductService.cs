using Renato.ECommerce.Domain.DTOs;
using Renato.ECommerce.Domain.Repositories.Interfaces;
using Renato.ECommerce.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renato.ECommerce.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;
        private readonly IUserContext userContext;


        public ProductService(IProductRepository repository, IUserContext userContext)
        {
            this.repository = repository ?? throw new ArgumentNullException("repositoty");
            this.userContext = userContext ?? throw new ArgumentNullException("userContext");
        }

        public IEnumerable<DiscountedProduct> GetFeaturedProducts()
        {
            return this.repository.GetFeaturedProducts()
                .Select(e => e.ApplyDiscountFor(this.userContext));
        }
    }
}
