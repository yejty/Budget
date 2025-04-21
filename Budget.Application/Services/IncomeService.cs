using Budget.Application.Models;
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
        public Task<bool> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(CreateIncomeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Income>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Income?> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Income?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Income?> UpdateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Income?> UpdateAsync(UpdateIncomeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
