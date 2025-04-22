using Budget.Application.Models;
using Budget.Contracts.Requests;
using Budget.Contracts.Responses;
using Microsoft.AspNetCore.Http.Features;

namespace Budget.API.Mapping
{
    public static class ContractMapping
    {
        public static Income MapToIncome(this CreateIncomeRequest request)
        {
            var income = new Income
            {
                Id = Guid.NewGuid(),
                Month = request.Month,
                Amount = request.Amount,
                Category = request.Category
            };
            return income;
        }

        public static Income MapToIncome(this UpdateIncomeRequest request, Guid id)
        {
            var income = new Income
            {
                Id = id,
                Month = request.Month,
                Amount = request.Amount,
                Category = request.Category
            };
            return income;
        }

        public static IncomeResponse MapToResponse(this Income income)
        {
            var incomeResponse = new IncomeResponse
            {
                Id = income.Id,
                Month = income.Month,
                Amount = income.Amount,
                Category = income.Category
            };
            return incomeResponse;
        }

        public static IncomesResponse MapToResponse(this IEnumerable<Income> incomes)
        {
            var incomesResponse = new IncomesResponse
            {
               Items = incomes.Select(MapToResponse)
            };
            return incomesResponse;
        }

        public static Expense MapToExpense(this CreateExpenseRequest request)
        {
            var expense = new Expense
            {
                Id = Guid.NewGuid(),
                Month = request.Month,
                Amount = request.Amount,
                Category = request.Category
            };
            return expense;
        }

        public static Expense MapToExpense(this UpdateExpenseRequest request, Guid id)
        {
            var expense = new Expense
            {
                Id = id,
                Month = request.Month,
                Amount = request.Amount,
                Category = request.Category
            };
            return expense;
        }

        public static ExpenseResponse MapToResponse(this Expense expense)
        {
            var expenseResponse = new ExpenseResponse
            {
                Id = expense.Id,
                Month = expense.Month,
                Amount = expense.Amount,
                Category = expense.Category
            };
            return expenseResponse;
        }

        public static ExpensesResponse MapToResponse(this IEnumerable<Expense> expenses)
        {
            var expensesResponse = new ExpensesResponse
            {
                Items = expenses.Select(MapToResponse)
            };
            return expensesResponse;
        }
    }
}
