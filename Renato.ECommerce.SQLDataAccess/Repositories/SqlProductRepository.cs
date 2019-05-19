using Renato.ECommerce.Domain.Models;
using Renato.ECommerce.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace Renato.ECommerce.SQLDataAccess.Repositories
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly CommerceContext context;

        public SqlProductRepository(CommerceContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Product> GetFeaturedProducts()
        {
            string query = "SELECT * FROM Products P";

            using (var con = context.Connection)
            {
                var produtos = con.Query<Product>(query);
                return produtos.Where(e => e.IsFeatured);
            }
        }
    }
}
