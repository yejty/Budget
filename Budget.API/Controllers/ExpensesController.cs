using Microsoft.AspNetCore.Mvc;
using Budget.Application.Services;
using Budget.Contracts.Requests;

namespace Budget.API.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService) 
        {
            _expenseService = expenseService;
        }

        [HttpGet(ApiEndpoints.Expenses.Get)]
        public IActionResult GetExpense(int id)
        {
            return Ok();
        }

        [HttpGet(ApiEndpoints.Expenses.GetAll)]
        public IActionResult GetAllExpenses()
        {
            return Ok();
        }

        [HttpPost(ApiEndpoints.Expenses.Create)]
        public IActionResult CreateExpense(CreateExpenseRequest createExpenseRequest)
        {
            return Created();
        }

        [HttpPut(ApiEndpoints.Expenses.Update)]
        public IActionResult UpdateExpense(int id, UpdateExpenseRequest updateExpenseRequest)
        {
            return Ok();
        }

        [HttpDelete(ApiEndpoints.Expenses.Delete)]
        public IActionResult DeleteExpense(int id)
        {
            return NoContent();
        }
    }
}
