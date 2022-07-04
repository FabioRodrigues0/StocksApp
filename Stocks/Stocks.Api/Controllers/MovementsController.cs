using System;
using System.Threading.Tasks;
using Infrastructure.Shared.Controller;
using Infrastructure.Shared.Services.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stock.Application.Commands;
using Stock.Application.Models;
using Stock.Application.Queries;

namespace Stock.Api.Controllers
{
	[Route("api/[controller]")]
	public class MovementsController : ApiControllerBase
	{
		private readonly ILogger<MovementsController> _logger;
		private readonly IMediator _mediator;

		public MovementsController(
			ILogger<MovementsController> logger,
			IMediator mediator,
			IServiceContext context) : base(context)
		{
			_logger = logger;
			_mediator = mediator;
		}

		/// <summary>
		/// Calls Page(int) of 10 Stocks in Database
		/// </summary>
		/// <returns>Page(int) of 10 Stocks in Data base</returns>
		/// <response code="200">Success response</response>
		/// <response code="204">Don't have any Stocks in Database</response>
		/// <response code="400">
		/// When a request error occurs but a message reporting the error is returned
		/// </response>
		[HttpGet("per/{itemsPerPage}/page/{page}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> Get([FromRoute] int page = 1, [FromRoute] int itemsPerPage = 10)
		{
			_logger.LogInformation("Begin Request for BuyRequests {page}", page);
			return ServiceResponse(await _mediator.Send(new GetAll { page = page, itemsPerPage = itemsPerPage }));
		}

		/// <summary>
		/// Gets Stocks in Database with ID indicated
		/// </summary>
		/// <returns>Stocks in Database with ID indicated</returns>
		/// <response code="200">Success response</response>
		/// <response code="204">Don't have a Stocks with ID indicated</response>
		/// <response code="400">
		/// When a request error occurs but a message reporting the error is returned
		/// </response>
		[HttpGet("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> Get([FromRoute] Guid id)
		{
			_logger.LogInformation("Begin Request for Stocks with Id = {id}", id);
			return ServiceResponse(await _mediator.Send(new GetById { Id = id }));
		}

		/// <summary>
		/// Create a new Stocks
		/// </summary>
		/// <returns>
		/// if have errors in validation indicates that if not return errors null and the Stocks inserted
		/// </returns>
		/// <response code="200">Success response</response>
		/// <response code="400">
		/// When a request error occurs but a message reporting the error is returned
		/// </response>
		[HttpPost]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> Post([FromBody] MovementsModel obj)
		{
			_logger.LogInformation("Begin Request for Create a Stocks({obj})", obj);
			return ServiceResponse(await _mediator.Send(new Post { Movements = obj }));
		}

		/// <summary>
		/// Send a Stocks
		/// </summary>
		/// <returns>
		/// if have errors in validation indicates that if not return errors null and the Stocks inserted
		/// </returns>
		/// <response code="200">Success response</response>
		/// <response code="400">
		/// When a request error occurs but a message reporting the error is returned
		/// </response>
		[HttpDelete("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> Remove([FromRoute] Guid id)
		{
			_logger.LogInformation("Begin Request for to delete a Stocks with Id = {id})", id);
			return ServiceResponse(await _mediator.Send(new Delete { Id = id }));
		}
	}
}