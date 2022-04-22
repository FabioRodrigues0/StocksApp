using FinancialApp.Application.Interface;
using FinancialApp.DTO.DTO;
using FinancialApp.Shared;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.API.CashBook.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CashBookController : Controller
	{
		private readonly IApplicationCashBookService _applicationCashBookService;

		public CashBookController(IApplicationCashBookService applicationCashBookService)
		{
			_applicationCashBookService = applicationCashBookService;
		}

		// GET api/values
		[HttpGet]
		public ActionResult<List<string>> Get()
		{
			return Ok(_applicationCashBookService.GetAll());
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(Guid id)
		{
			return Ok(_applicationCashBookService.GetById(id));
		}

		[HttpGet("page/{page}")]
		public ActionResult<string> Get(int page)
		{
			return Ok(_applicationCashBookService.GetByPage(page));
		}

		// POST api/values
		[HttpPost]
		public async Task<ActionResult> Post([FromBody] CashBookDto cashBookDto)
		{
			if(cashBookDto == null)
				return NoContent();
			await _applicationCashBookService.Add(cashBookDto);
			return Ok("Cash Book successfully registered!");
		}

		// PUT api/values/5
		[HttpPut]
		public ActionResult Put([FromBody] CashBookDto cashBookDto)
		{
			if(cashBookDto == null)
				return NotFound();

			_applicationCashBookService.Update(cashBookDto);
			return Ok("Cash Book successfully updated!");
		}

		// DELETE api/values/5
		[HttpDelete]
		public ActionResult Delete([FromBody] CashBookDto cashBookDto)
		{
			if(cashBookDto == null)
				return NotFound();

			_applicationCashBookService.Remove(cashBookDto);
			return Ok("Cash Book successfully remove!");
		}

		// PATCH api/values/5
		[HttpPatch("{id}")]
		public async Task<IActionResult> Patch([FromBody] JsonPatchDocument cashBook, [FromRoute] Guid id)
		{
			var result = _applicationCashBookService.GetById(id);
			if(result == null)
				return NotFound();
			result.Type = StatusCashBook.Reversal;
			await _applicationCashBookService.Patch(cashBook, id);
			return Ok("Cash Book successfully remove!");
		}
	}
}