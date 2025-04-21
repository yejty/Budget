using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Contracts.Requests
{
    public class UpdateExpenseRequest
    {
        public required DateTime Month { get; init; }

        public required decimal Amount { get; init; }

        public required IEnumerable<string> Category { get; init; } = Enumerable.Empty<string>();
    }
}
