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
        Task<bool> CreateAsync(CreateExpenseRequest request);

        Task<Income?> GetAsync(int id);

        Task<IEnumerable<Income>> GetAllAsync();

        Task<Income?> UpdateAsync(UpdateExpenseRequest request);

        Task<bool> DeleteAsync(int id);
    }
}
