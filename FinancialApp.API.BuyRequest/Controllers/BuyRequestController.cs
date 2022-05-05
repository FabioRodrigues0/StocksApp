using FinancialApp.Application.Interface;
using FinancialApp.DTO.DTO;
using FinancialApp.Shared.Controller;
using FinancialApp.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.API.BuyRequest.Controllers;

[Route("api/[controller]")]
public class BuyRequestController : ApiControllerBase
{
	private readonly ILogger<BuyRequestController> _logger;
	private readonly IApplicationBuyRequestService _applicationBuyRequestService;

	public BuyRequestController(
		IApplicationBuyRequestService applicationBuyRequestService,
		ILogger<BuyRequestController> logger,
		IServiceContext context) : base(context)
	{
		_logger = logger;
		_applicationBuyRequestService = applicationBuyRequestService;
	}

	/// <summary>
	/// Calls Page(int) of 10 BuyRequests in Data base
	/// </summary>
	/// <returns>Page(int) of 10 BuyRequest in Data base</returns>
	/// <response code="200">Success response</response>
	/// <response code="400">
	/// When a request error occurs but a message reporting the error is returned
	/// </response>
	[HttpGet("page/{page}")]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<ActionResult<string>> Get([FromRoute] int page)
	{
		var result = await _applicationBuyRequestService.GetAll(page);
		if(result != null)
			return Ok(result);
		return NoContent();
	}

	/// <summary>
	/// Gets BuyRequest in Data base with ID indicated or Client
	/// </summary>
	/// <returns>BuyRequest in Data base with ID indicated or Client</returns>
	/// <response code="200">Success response</response>
	/// <response code="400">
	/// When a request error occurs but a message reporting the error is returned
	/// </response>
	[HttpGet("{id}")]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<ActionResult<string>> Get([FromRoute] Guid id)
	{
		var result = await _applicationBuyRequestService.GetById(id);
		if(result != null)
			return Ok(result);
		return NoContent();
	}

	/// <summary>
	/// Send a BuyRequest
	/// </summary>
	/// <returns>
	/// if have errors in validation indicates that if not return errors null and the BuyRequest inserted
	/// </returns>
	/// <response code="200">Success response</response>
	/// <response code="400">
	/// When a request error occurs but a message reporting the error is returned
	/// </response>
	[HttpPost]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<IActionResult> Post([FromBody] BuyRequestDto buyRequestDto)
	{
		return ServiceResponse(await _applicationBuyRequestService.Add(buyRequestDto));
	}

	/// <summary>
	/// Send a Update to BuyRequest
	/// </summary>
	/// <returns>
	/// if have errors in validation indicates that if not return errors null and the BuyRequest updated
	/// </returns>
	/// <response code="200">Success response</response>
	/// <response code="400">
	/// When a request error occurs but a message reporting the error is returned
	/// </response>
	[HttpPut]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<IActionResult> Put([FromBody] BuyRequestUpdateDto obj)
	{
		return ServiceResponse(await _applicationBuyRequestService.Update(obj));
	}

	/// <summary>
	/// Send a Update to Status of BuyRequest
	/// </summary>
	/// <returns>
	/// if have errors in validation indicates that if not return null and the BuyRequest updated
	/// </returns>
	/// <response code="200">Success response</response>
	/// <response code="400">
	/// When a request error occurs but a message reporting the error is returned
	/// </response>
	[HttpPatch]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<IActionResult> Patch([FromBody] BuyRequestPatchDto obj)
	{
		return ServiceResponse(await _applicationBuyRequestService.Patch(obj));
	}

	/// <summary>
	/// Send a Request to Delete a BuyRequest
	/// </summary>
	/// <returns>BuyRequest Deleted</returns>
	/// <response code="200">Success response</response>
	/// <response code="400">
	/// When a request error occurs but a message reporting the error is returned
	/// </response>
	[HttpDelete("{id}")]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<IActionResult> Delete([FromRoute] Guid id)
	{
		return ServiceResponse(await _applicationBuyRequestService.Remove(id));
	}
}