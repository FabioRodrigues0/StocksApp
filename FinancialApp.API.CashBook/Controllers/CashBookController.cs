using AutoMapper;
using FinancialApp.Application.Interface;
using FinancialApp.DTO.DTO;
using FinancialApp.Shared.Controller;
using FinancialApp.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.API.CashBook.Controllers;

[Route("api/[controller]")]
public class CashBookController : ApiControllerBase
{
	private readonly ILogger<CashBookController> _logger;
	private readonly IApplicationCashBookService _applicationCashBookService;

	public CashBookController(
		IApplicationCashBookService applicationCashBookService,
		ILogger<CashBookController> logger,
		IServiceContext context) : base(context)
	{
		_logger = logger;
		_applicationCashBookService = applicationCashBookService;
	}

	/// <summary>
	/// Calls 10 CashBook in Data base
	/// </summary>
	/// <returns>10 CashBook in Data base</returns>
	/// <response code="200">Success response</response>
	/// <response code="400">
	/// When a request error occurs but a message reporting the error is returned
	/// </response>
	[HttpGet("page/{page}")]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<ActionResult<string>> Get(int page)
	{
		var result = await _applicationCashBookService.GetAll(page);
		if(result != null)
			return Ok(result);
		return NoContent();
	}

	/// <summary>
	/// Gets CashBook in Data base with ID indicated
	/// </summary>
	/// <returns>BuyRequest in Data base with ID indicated</returns>
	/// <response code="200">Success response</response>
	/// <response code="400">
	/// When a request error occurs but a message reporting the error is returned
	/// </response>
	[HttpGet("{id}")]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<ActionResult<string>> Get(Guid id)
	{
		var result = await _applicationCashBookService.GetById(id);
		if(result != null)
			return Ok(result);
		return NoContent();
	}

	/// <summary>
	/// Gets CashBook in Data base with OriginID indicated
	/// </summary>
	/// <returns>BuyRequest in Data base with OriginID indicated</returns>
	/// <response code="200">Success response</response>
	/// <response code="400">
	/// When a request error occurs but a message reporting the error is returned
	/// </response>
	[HttpGet("origin/{id}")]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<ActionResult<string>> GetOriginId(Guid id)
	{
		var result = await _applicationCashBookService.GetByOriginId(id);
		if(result != null)
			return Ok(result);
		return NoContent();
	}

	/// <summary>
	/// Send a CashBook
	/// </summary>
	/// <returns>
	/// if have errors in validation indicates that if not return errors null and the CashBook inserted
	/// </returns>
	/// <response code="200">Success response</response>
	/// <response code="400">
	/// When a request error occurs but a message reporting the error is returned
	/// </response>
	[HttpPost]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<IActionResult> Post([FromBody] CashBookDto cashBookDto)
	{
		return ServiceResponse(await _applicationCashBookService.Add(cashBookDto));
	}

	/// <summary>
	/// Send a Update to CashBook
	/// </summary>
	/// <returns>
	/// if have errors in validation indicates that if not return errors null and the CashBook updated
	/// </returns>
	/// <response code="200">Success response</response>
	/// <response code="400">
	/// When a request error occurs but a message reporting the error is returned
	/// </response>
	[HttpPut]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<IActionResult> Put([FromBody] CashBookUpdateDto obj)
	{
		return ServiceResponse(await _applicationCashBookService.Update(obj));
	}
}