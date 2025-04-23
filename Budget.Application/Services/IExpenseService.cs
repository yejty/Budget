using Budget.Application.Models;
using Budget.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public interface IExpenseService
    {
        Task<bool> CreateAsync(Expense expense);

        Task<Expense?> GetAsync(Guid id);

        Task<IEnumerable<Expense>> GetAllAsync();
        
        Task<Expense?> UpdateAsync(Expense expense);

        Task<bool> DeleteAsync(Guid id);
    }
}
