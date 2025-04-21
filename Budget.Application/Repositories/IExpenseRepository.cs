using Budget.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Repositories
{
    public interface IExpenseRepository
    {
        Task<bool> CreateAsync(Expense expense);

        Task<Expense?> GetByIdAsync(Guid id);

        Task<IEnumerable<Expense>> GetAllAsync();

        Task<bool> UpdateAsync(Expense expense);

        Task<bool> DeleteByIdAsync(Guid id);
    }
}
