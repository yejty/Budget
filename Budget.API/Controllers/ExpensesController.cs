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
            var response = expenses.MapToResponse();
            return Ok(response);
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
        public async Task <IActionResult> UpdateExpense([FromRoute]Guid id, [FromBody]UpdateExpenseRequest request)
        {
            var expense = request.MapToExpense(id);
            var updated = await _expenseRepository.UpdateAsync(expense);
            if (!updated)
            {
                return NotFound();
            }
            var response = expense.MapToResponse();
            return Ok(response);
        }

        [HttpDelete(ApiEndpoints.Expenses.Delete)]
        public async Task<IActionResult> DeleteExpense([FromRoute]Guid id)
        {
            var deleted = await _expenseRepository.DeleteByIdAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
