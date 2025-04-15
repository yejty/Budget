using Budget.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Repositories
{
    public interface IIncomeRepository
    {
        Task<bool> CreateAsync(Income income);

        Task<Income?> GetByIdAsync(int id);

        Task<IEnumerable<Income>> GetAllAsync();

        Task<bool> UpdateAsync(Income income);

        Task<bool> DeleteByIdAsync(int id);

    }
}
