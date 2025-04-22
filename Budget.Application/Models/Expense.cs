using Budget.Application.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Models
{
    public class Expense
    {
        public required Guid Id { get; init; }

        public required DateTime Month { get; set; } = DateTime.MinValue;

        public required decimal Amount { get; set; } = 0;

        public required string Category { get; set; } = string.Empty;
    }
}
