using Budget.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly List<Expense> _expenses = new();

        public Task<bool> CreateAsync(Expense expense)
        {
            _expenses.Add(expense);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteByIdAsync(Guid id)
        {
            var removedCount = _expenses.RemoveAll(x => x.Id == id);
            var movieRemoved = removedCount > 0;
            return Task.FromResult(movieRemoved);
        }

        public Task<IEnumerable<Expense>> GetAllAsync()
        {
            return Task.FromResult(_expenses.AsEnumerable());
        }

        public Task<Expense?> GetByIdAsync(Guid id)
        {
            var income = _expenses.SingleOrDefault(x => x.Id == id);
            return Task.FromResult(income);
        }

        public Task<bool> UpdateAsync(Expense expense)
        {
            var incomeIndex = _expenses.FindIndex(x => x.Id == expense.Id);
            if (incomeIndex == -1)
            {
                return Task.FromResult(false);
            }
            _expenses[incomeIndex] = expense;
            return Task.FromResult(true);
        }
    }
}
