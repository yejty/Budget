using Budget.Application.Models;
using Budget.Contracts.Requests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public interface IIncomeService
    {
        Task<bool> CreateAsync(Income income);

        Task<Income?> GetAsync(Guid id);

        Task<IEnumerable<Income>> GetAllAsync();

        Task<Income?> UpdateAsync(Income income);

        Task<bool> DeleteAsync(Guid id);
    }
}
