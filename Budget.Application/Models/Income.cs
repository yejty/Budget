using Budget.Application.Models.Enums;

namespace Budget.Application.Models
{
    public class Income
    {
        public int Id {set; get;}

        public DateTime Month { set; get; } = DateTime.MinValue;

        public decimal Amount { get; set; } = 0;

        public IncomeCategory Category { set; get; } = IncomeCategory.Salary;
    }
}
