using System;
using System.Threading.Tasks;
using Infrastructure.Shared.Controller;
using Infrastructure.Shared.Services.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stock.Application.Queries;

namespace Stock.Api.Controllers
{
	[Route("api/[controller]")]
	public class ProductController : ApiControllerBase
	{
		private readonly ILogger<ProductController> _logger;
		private readonly IMediator _mediator;

		public ProductController(
			ILogger<ProductController> logger,
			IMediator mediator,
			IServiceContext context) : base(context)
		{
			_logger = logger;
			_mediator = mediator;
		}

		/// <summary>
		/// Calls Page(int) of 10 BuyRequests in Database
		/// </summary>
		/// <returns>Page(int) of 10 BuyRequest in Data base</returns>
		/// <response code="200">Success response</response>
		/// <response code="204">Don't have any BuyRequest in Database</response>
		/// <response code="400">
		/// When a request error occurs but a message reporting the error is returned
		/// </response>
		[HttpGet("page/{page}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> Get([FromRoute] int page)
		{
			_logger.LogInformation("Begin Request for Products {page}", page);
			return ServiceResponse(await _mediator.Send(new GetAllProducts { page = page }));
		}

		/// <summary>
		/// Gets BuyRequest in Database with ID indicated
		/// </summary>
		/// <returns>BuyRequest in Database with ID indicated</returns>
		/// <response code="200">Success response</response>
		/// <response code="204">Don't have a BuyRequest with ID indicated</response>
		/// <response code="400">
		/// When a request error occurs but a message reporting the error is returned
		/// </response>
		[HttpGet("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> Get([FromRoute] Guid id)
		{
			_logger.LogInformation("Begin Request for Product with Id = {id}", id);
			return ServiceResponse(await _mediator.Send(new GetProductById { Id = id }));
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
		[HttpGet("{id}/storage/{storageId}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> Get([FromRoute] Guid id, Guid storageId)
		{
			_logger.LogInformation("Begin Request for Product with Id = {id} and StorageId = {storageId}", id, storageId);
			return ServiceResponse(await _mediator.Send(new GetProductByIdWithStorageId { Id = id, StorageId = storageId }));
		}
	}
}