using Budget.Application.Database;
using Budget.Application.Models;
using Dapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public IncomeRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;  
        }

        public async Task<bool> CreateAsync(Income income)
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            using var transaction = connection.BeginTransaction();

            var result = await connection.ExecuteAsync(new CommandDefinition("""
                insert into incomes (id, month, amount, category)
                values (@Id, @Month, @Amount, @Category)
                """, income));

            transaction.Commit();

            return result > 0;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            using var transaction = connection.BeginTransaction();

            var result = await connection.ExecuteAsync(
               new CommandDefinition("""
                    DELETE FROM incomes
                    WHERE id = @id
                """, new { id }));

            transaction.Commit();
            return result > 0;
        }

        public async Task<IEnumerable<Income>> GetAllAsync()
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();

            var incomes = await connection.QueryAsync<Income>(
                new CommandDefinition("""
                SELECT * FROM incomes
                """));

            return incomes;
        }

        public async Task<Income?> GetByIdAsync(Guid id)
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            
            var income = await connection.QuerySingleOrDefaultAsync<Income>(
                new CommandDefinition("""
                select * from incomes where id = @id
                """, new { id }));

            if (income == null)
            {
                return null;
            }
            
            return income;
        }

        public async Task<bool> UpdateAsync(Income income)
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            using var transaction = connection.BeginTransaction();

            var result = await connection.ExecuteAsync(
               new CommandDefinition("""
                    UPDATE incomes
                    SET month = @Month,
                    amount = @Amount,
                    category = @Category
                    WHERE id = @Id
                """, income));

            transaction.Commit();
            return result > 0;
        }
    }
}
