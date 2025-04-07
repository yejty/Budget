using Budget.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class ExpenseService : IExpenseService
    {
        public Task<bool> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync()
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

        public Task<Income?> UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
