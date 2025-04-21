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
        private readonly IIncomeRepository _incomeRepository;

        public IncomesController(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        [HttpGet(ApiEndpoints.Incomes.Get)]
        public async Task<IActionResult> GetIncome([FromRoute] Guid id)
        {
            var income = await _incomeRepository.GetByIdAsync(id);
            if (income == null)
            {
                return NotFound();
            }
            var response = income.MapToResponse();
            return Ok(); 
        }

        [HttpGet(ApiEndpoints.Incomes.GetAll)]
        public async Task<IActionResult> GetAllIncomes()
        {
            var incomes = await _incomeRepository.GetAllAsync();
            var incomesResponse = incomes.MapToResponse();
            return Ok(incomesResponse);
        }

        [HttpPost(ApiEndpoints.Incomes.Create)]
        public async Task<IActionResult> CreateIncome([FromBody] CreateIncomeRequest request)
        {
            var income = request.MapToIncome();
            await _incomeRepository.CreateAsync(income);
            var response = income.MapToResponse();
            return CreatedAtAction(nameof(GetIncome), new { id = income.Id}, response);
        }

        [HttpPut(ApiEndpoints.Incomes.Update)]
        public async Task<IActionResult> UpdateIncome([FromRoute] Guid id, [FromBody] UpdateIncomeRequest request)
        {
            var income = request.MapToIncome(id);
            var updated = await _incomeRepository.UpdateAsync(income);
            if (!updated)
            {
                return NotFound();
            }
            var response = income.MapToResponse();
            return Ok(response);
        }

        [HttpDelete(ApiEndpoints.Incomes.Delete)]
        public async Task<IActionResult> DeleteIncome([FromRoute] Guid id)
        {
            var deleted = await _incomeRepository.DeleteByIdAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}