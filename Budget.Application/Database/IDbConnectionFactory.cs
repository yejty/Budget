using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Database
{
    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsync();
    }

    public class NpqsqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public NpqsqlConnectionFactory(string connectiongString)
        {
            _connectionString = connectiongString;
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
