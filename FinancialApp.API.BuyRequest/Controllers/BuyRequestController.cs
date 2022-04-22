using FinancialApp.Application.Interface;
using FinancialApp.DTO.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;

namespace FinancialApp.API.BuyRequest.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BuyRequestController : Controller
	{
		private readonly IApplicationBuyRequestService _applicationBuyRequestService;

		public BuyRequestController(IApplicationBuyRequestService applicationBuyRequestService)
		{
			_applicationBuyRequestService = applicationBuyRequestService;
		}

		// GET api/values
		[HttpGet]
		public ActionResult<string> Get()
		{
			var result = _applicationBuyRequestService.GetAll();
			if(result != null)
				return Ok(result);
			return NoContent();
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(Guid id)
		{
			var result = _applicationBuyRequestService.GetById(id);
			if(result != null)
				return Ok(result);
			return NoContent();
		}

		[HttpGet("page/{page}")]
		public ActionResult<string> Get(int page)
		{
			var result = _applicationBuyRequestService.GetByPage(page);
			if(result != null)
				return Ok(result);
			return NoContent();
		}

		// POST api/values
		[HttpPost]
		public async Task<ActionResult> Post([FromBody] BuyRequestDto buyRequestDto)
		{
			if(buyRequestDto == null)
				return NotFound();

			await _applicationBuyRequestService.Add(buyRequestDto);
			return Ok("Buy Request successfully registered!");
		}

		// PUT api/values/5
		[HttpPut]
		public ActionResult Put([FromBody] BuyRequestDto buyRequestDto)
		{
			if(buyRequestDto == null)
				return NotFound();

			_applicationBuyRequestService.Update(buyRequestDto);
			return Ok("Buy Request successfully updated!");
		}

		[HttpPatch]
		public async Task<ActionResult> Patch([FromBody] JsonPatchDocument buyRequest, Guid id)
		{
			var result = _applicationBuyRequestService.GetById(id);
			if(result == null)
				return NotFound();
			await _applicationBuyRequestService.Patch(buyRequest, id);
			return Ok("Buy Request successfully updated!");
		}

		// DELETE api/values/5
		[HttpDelete]
		public ActionResult Delete([FromBody] Guid id)
		{
			var result = _applicationBuyRequestService.GetById(id);
			if(result == null)
				return NotFound();

			_applicationBuyRequestService.Remove(result);
			return Ok("Buy Request successfully removed!");
		}
	}
}