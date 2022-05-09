using FinancialApp.Application.Interface;
using FinancialApp.DTO.DTO;
using FinancialApp.Shared.Controller;
using FinancialApp.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.API.Document.Controllers;

[Route("api/[controller]")]
public class DocumentController : ApiControllerBase
{
	private readonly ILogger<DocumentController> _logger;
	private readonly IApplicationDocumentService _applicationDocumentService;

	public DocumentController(
		IApplicationDocumentService applicationDocumentService,
		ILogger<DocumentController> logger,
		IServiceContext context) : base(context)
	{
		_logger = logger;
		_applicationDocumentService = applicationDocumentService;
	}

	/// <summary>
	/// Calls Page(int) of 10 Documents in Database
	/// </summary>
	/// <returns>Page(int) of 10 Documents in Data base</returns>
	/// <response code="200">Success response</response>
	/// <response code="400">
	/// When a request error occurs but a message reporting the error is returned
	/// </response>
	[HttpGet("page/{page}")]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<ActionResult<string>> Get([FromRoute] int page)
	{
		var result = await _applicationDocumentService.GetAll(page);
		if (result != null)
			return Ok(result);
		return NoContent();
	}

	/// <summary>
	/// Gets Document in Database with ID indicated
	/// </summary>
	/// <returns>Document in Data base with ID indicated</returns>
	/// <response code="200">Success response</response>
	/// <response code="400">
	/// When a request error occurs but a message reporting the error is returned
	/// </response>
	[HttpGet("{id}")]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<ActionResult<string>> Get([FromRoute] Guid id)
	{
		var result = await _applicationDocumentService.GetById(id);
		if (result != null)
			return Ok(result);
		return NoContent();
	}

	/// <summary>
	/// Send a Document
	/// </summary>
	/// <returns>
	/// if have errors in validation indicates that if not return errors null and the Document inserted
	/// </returns>
	/// <response code="200">Success response</response>
	/// <response code="400">
	/// When a request error occurs but a message reporting the error is returned
	/// </response>
	[HttpPost]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<IActionResult> Post([FromBody] DocumentDto documentDto)
	{
		return ServiceResponse(await _applicationDocumentService.Add(documentDto));
	}

	/// <summary>
	/// Send a Update to Document
	/// </summary>
	/// <returns>
	/// if have errors in validation indicates that if not return errors null and the Document updated
	/// </returns>
	/// <response code="200">Success response</response>
	/// <response code="400">
	/// When a request error occurs but a message reporting the error is returned
	/// </response>
	[HttpPut]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<IActionResult> Put([FromBody] DocumentUpdateDto obj)
	{
		return ServiceResponse(await _applicationDocumentService.Update(obj));
	}

	/// <summary>
	/// Send a Request to Delete a Document
	/// </summary>
	/// <returns>Document Deleted</returns>
	/// <response code="200">Success response</response>
	/// <response code="400">
	/// When a request error occurs but a message reporting the error is returned
	/// </response>
	[HttpDelete("{id}")]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<IActionResult> Delete([FromRoute] Guid id)
	{
		return ServiceResponse(await _applicationDocumentService.Remove(id));
	}

	/// <summary>
	/// Send a Update to Paid of Document
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
	public async Task<IActionResult> Patch([FromBody] DocumentPatchDto obj)
	{
		return ServiceResponse(await _applicationDocumentService.Patch(obj));
	}
}