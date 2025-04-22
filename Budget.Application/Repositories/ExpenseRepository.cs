using Budget.Application.Database;
using Budget.Application.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public ExpenseRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> CreateAsync(Expense expense)
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            using var transaction = connection.BeginTransaction();

            var result = await connection.ExecuteAsync(new CommandDefinition("""
                insert into expenses (id, month, amount, category)
                values (@Id, @Month, @Amount, @Category)
                """, expense));

            transaction.Commit();

            return result > 0;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            using var transaction = connection.BeginTransaction();

            var result = await connection.ExecuteAsync(
               new CommandDefinition("""
                    DELETE FROM expenses
                    WHERE id = @id
                """, new { id }));

            transaction.Commit();
            return result > 0;
        }

        public async Task<IEnumerable<Expense>> GetAllAsync()
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();

            var expenses = await connection.QueryAsync<Expense>(
                new CommandDefinition("""
                SELECT * FROM expenses
                """));

            return expenses;
        }

        public async Task<Expense?> GetByIdAsync(Guid id)
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();

            var expense = await connection.QuerySingleOrDefaultAsync<Expense>(
                new CommandDefinition("""
                select * from expenses where id = @id
                """, new { id }));

            if (expense == null)
            {
                return null;
            }

            return expense;
        }

        public async Task<bool> UpdateAsync(Expense expense)
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            using var transaction = connection.BeginTransaction();

            var result = await connection.ExecuteAsync(
               new CommandDefinition("""
                    UPDATE expenses
                    SET month = @Month,
                    amount = @Amount,
                    category = @Category
                    WHERE id = @id
                """, expense));

            transaction.Commit();
            return result > 0;
        }
    }
}
