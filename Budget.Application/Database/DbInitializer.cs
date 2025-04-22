using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Database
{
    public class DbInitializer
    {
        private readonly IDbConnectionFactory _dbconnectionFactory;

        public DbInitializer(IDbConnectionFactory dbconnectionFactory)
        {
            _dbconnectionFactory = dbconnectionFactory;
        }

        public async Task InitializeAsync()
        {
            using var connection = await _dbconnectionFactory.CreateConnectionAsync();
            await connection.ExecuteAsync("""
                CREATE TABLE IF NOT EXISTS incomes (
                id UUID PRIMARY KEY,
                month DATE NOT NULL,
                amount NUMERIC(12, 2) NOT NULL,
                category TEXT NOT NULL
                )
            """);

            await connection.ExecuteAsync("""
                CREATE TABLE IF NOT EXISTS expenses (
                id UUID PRIMARY KEY,
                month DATE NOT NULL,
                amount NUMERIC(12, 2) NOT NULL,
                category TEXT NOT NULL
                )
            """);
        }
    }
}
