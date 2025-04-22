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
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;

        public Task<bool> CreateAsync(Income income)
        {
            return _incomeRepository.CreateAsync(income);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _incomeRepository.DeleteByIdAsync(id);
        }

        public Task<IEnumerable<Income>> GetAllAsync()
        {
            return _incomeRepository.GetAllAsync();
        }

        public Task<Income?> GetAsync(Guid id)
        {
            return _incomeRepository.GetByIdAsync(id);
        }

        public Task<Income?> UpdateAsync(Income income)
        {
            return _incomeRepository.UpdateAsync(income);
        }
    }
}
