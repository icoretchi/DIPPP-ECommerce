using System;
using Microsoft.EntityFrameworkCore;
using Renato.ECommerce.Domain.Models;

namespace Renato.ECommerce.SQLDataAccess
{
    public class CommerceContext : DbContext
    {
        private readonly string connectionString;

        public CommerceContext(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Value should not be null nor empty.", nameof(connectionString));

            this.connectionString = connectionString;
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.connectionString);
        }
    }
}
