using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Contracts.Responses
{
    public class ExpenseResponse
    {
        public required Guid Id { get; set; }

        public required DateTime Month { get; set; }

        public required decimal Amount { get; set; }

        public required string Category { get; set; } = string.Empty;
    }
}
