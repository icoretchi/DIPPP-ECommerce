using System;
using Microsoft.EntityFrameworkCore;
using Renato.ECommerce.Domain.Models;
using System.Data.SqlClient;

namespace Renato.ECommerce.SQLDataAccess
{
    public class CommerceContext : IDisposable
    {
        private readonly string connectionString;
        
        private SqlConnection _connection;
        public SqlConnection Connection => _connection ?? (_connection = GetOpenConnection());

        public CommerceContext(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Value should not be null nor empty.", nameof(connectionString));

            this.connectionString = connectionString;
        }

        private SqlConnection GetOpenConnection()
        {   
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
