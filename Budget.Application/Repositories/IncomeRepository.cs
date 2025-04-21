using Budget.Application.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly List<Income> _incomes = new();

        public Task<bool> CreateAsync(Income income)
        {
            _incomes.Add(income);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteByIdAsync(Guid id)
        {
            var removedCount = _incomes.RemoveAll(x => x.Id == id);
            var movieRemoved = removedCount > 0;
            return Task.FromResult(movieRemoved);
        }

        public Task<IEnumerable<Income>> GetAllAsync()
        {
            return Task.FromResult(_incomes.AsEnumerable());
        }

        public Task<Income?> GetByIdAsync(Guid id)
        {
            var income = _incomes.SingleOrDefault(x => x.Id == id);
            return Task.FromResult(income);
        }

        public Task<bool> UpdateAsync(Income income)
        {
            var incomeIndex = _incomes.FindIndex(x => x.Id == income.Id);
            if (incomeIndex == -1) 
            {
                return Task.FromResult(false);
            }
            _incomes[incomeIndex] = income;
            return Task.FromResult(true);
        }
    }
}
