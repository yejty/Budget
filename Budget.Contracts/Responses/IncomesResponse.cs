using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Contracts.Responses
{
    public class IncomesResponse
    {
        public required IEnumerable<IncomeResponse> Items { get; set; } = Enumerable.Empty<IncomeResponse>(); 
    }
}
