using Budget.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public interface IExpenseService
    {
        Task<bool> CreateAsync();

        Task<Income?> GetAsync();

        Task<IEnumerable<Income>> GetAllAsync();

        Task<Income?> UpdateAsync();

        Task<bool> DeleteAsync();
    }
}
