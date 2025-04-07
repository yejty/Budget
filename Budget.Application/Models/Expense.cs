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
        public int Id { set; get; }

        public DateTime Month { set; get; } = DateTime.MinValue;

        public decimal Amount { get; set; } = 0;

        public ExpenseCategory Category { set; get; } = ExpenseCategory.Other;
    }
}
