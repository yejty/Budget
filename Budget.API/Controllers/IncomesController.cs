using Budget.API;
using Budget.Application.Services;
using Budget.Contracts.Requests;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Controllers
{
    public class IncomesController : Controller
    {
        private readonly IIncomeService _incomeService;

        public IncomesController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpGet(ApiEndpoints.Incomes.Get)]
        public IActionResult GetIncome(int id)
        {
            return Ok();
        }

        [HttpGet(ApiEndpoints.Incomes.GetAll)]
        public IActionResult GetAllIncomes()
        {
            return Ok();
        }

        [HttpPost(ApiEndpoints.Incomes.Create)]
        public IActionResult CreateIncome(CreateIncomeRequest createIncomeRequest)
        {
            return Created();
        }

        [HttpPut(ApiEndpoints.Incomes.Update)]
        public IActionResult UpdateIncome(int id, UpdateIncomeRequest updateIncomeRequest)
        {
            return Ok();
        }

        [HttpDelete(ApiEndpoints.Incomes.Delete)]
        public IActionResult DeleteIncome(int id)
        {
            return NoContent();
        }
    }
}
