using Budget.Application.Models;
using Budget.Application.Repositories;
using Budget.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public Task<bool> CreateAsync(Expense expense)
        {
            return _expenseRepository.CreateAsync(expense);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _expenseRepository.DeleteByIdAsync(id);
        }

        public Task<IEnumerable<Expense>> GetAllAsync()
        {
            return _expenseRepository.GetAllAsync();
        }

        public Task<Expense?> GetAsync(Guid id)
        {
            return _expenseRepository.GetByIdAsync(id);
        }

        public async Task<Expense?> UpdateAsync(Expense expense)
        {
            await _expenseRepository.UpdateAsync(expense);
            return expense;
        }
    }
}
