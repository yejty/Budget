using Microsoft.AspNetCore.Mvc;
using Budget.Application.Services;
using Budget.Contracts.Requests;
using Budget.Application.Repositories;
using Budget.API.Mapping;
using Budget.Application.Models;
using static Budget.API.ApiEndpoints;

namespace Budget.API.Controllers
{
    [ApiController]
    public class ExpensesController : Controller
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpensesController(IExpenseRepository expenseRepository) 
        {
            _expenseRepository = expenseRepository;
        }

        [HttpGet(ApiEndpoints.Expenses.Get)]
        public async Task<IActionResult> GetExpense([FromRoute]Guid id)
        {
            var expense = await _expenseRepository.GetByIdAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            var response = expense.MapToResponse();
            return Ok(response);
        }

        [HttpGet(ApiEndpoints.Expenses.GetAll)]
        public async Task<IActionResult> GetAllExpenses()
        {
            var expenses = await _expenseRepository.GetAllAsync();
            var responses= expenses.MapToResponse();
            return Ok();
        }

        [HttpPost(ApiEndpoints.Expenses.Create)]
        public async Task<IActionResult> CreateExpense([FromBody]CreateExpenseRequest request)
        {
            var expense = request.MapToExpense();
            await _expenseRepository.CreateAsync(expense);
            var response = expense.MapToResponse();
            return CreatedAtAction(nameof(GetExpense), new { id = expense.Id }, response);;
        }

        [HttpPut(ApiEndpoints.Expenses.Update)]
        public IActionResult UpdateExpense([FromRoute]Guid id, [FromBody]UpdateExpenseRequest updateExpenseRequest)
        {
            return Ok();
        }

        [HttpDelete(ApiEndpoints.Expenses.Delete)]
        public IActionResult DeleteExpense([FromRoute]Guid id)
        {
            return NoContent();
        }
    }
}
