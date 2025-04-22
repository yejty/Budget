using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Contracts.Responses
{
    public class ExpensesResponse
    {
        public required IEnumerable<ExpenseResponse> Items { get; set; } = Enumerable.Empty<ExpenseResponse>();
    }
}
