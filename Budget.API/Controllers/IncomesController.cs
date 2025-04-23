using Budget.API;
using Budget.API.Mapping;
using Budget.Application.Models;
using Budget.Application.Repositories;
using Budget.Application.Services;
using Budget.Contracts.Requests;
using Budget.Contracts.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Controllers
{
    [ApiController]
    public class IncomesController : Controller
    {
        private readonly IIncomeService _incomeService;

        public IncomesController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpGet(ApiEndpoints.Incomes.Get)]
        public async Task<IActionResult> GetIncome([FromRoute] Guid id)
        {
            var income = await _incomeService.GetAsync(id);
            if (income == null)
            {
                return NotFound();
            }
            var response = income.MapToResponse();
            return Ok(response); 
        }

        [HttpGet(ApiEndpoints.Incomes.GetAll)]
        public async Task<IActionResult> GetAllIncomes()
        {
            var incomes = await _incomeService.GetAllAsync();
            var incomesResponse = incomes.MapToResponse();
            return Ok(incomesResponse);
        }

        [HttpPost(ApiEndpoints.Incomes.Create)]
        public async Task<IActionResult> CreateIncome([FromBody] CreateIncomeRequest request)
        {
            var income = request.MapToIncome();
            await _incomeService.CreateAsync(income);
            var response = income.MapToResponse();
            return CreatedAtAction(nameof(GetIncome), new { id = income.Id}, response);
        }

        [HttpPut(ApiEndpoints.Incomes.Update)]
        public async Task<IActionResult> UpdateIncome([FromRoute] Guid id, [FromBody] UpdateIncomeRequest request)
        {
            var income = request.MapToIncome(id);
            var updatedIncome = await _incomeService.UpdateAsync(income);
            if (updatedIncome is null)
            {
                return NotFound();
            }
            var response = income.MapToResponse();
            return Ok(response);
        }

        [HttpDelete(ApiEndpoints.Incomes.Delete)]
        public async Task<IActionResult> DeleteIncome([FromRoute] Guid id)
        {
            var deleted = await _incomeService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}