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
	public class DashboardController : ApiControllerBase
	{
		private readonly ILogger<DashboardController> _logger;
		private readonly IMediator _mediator;

		public DashboardController(
			ILogger<DashboardController> logger,
			IMediator mediator,
			IServiceContext context) : base(context)
		{
			_logger = logger;
			_mediator = mediator;
		}

		/// <summary>
		/// Calls Page(int) of 10 Products in Database
		/// </summary>
		/// <returns>Page(int) of 10 Products in Data base</returns>
		/// <response code="200">Success response</response>
		/// <response code="204">Don't have any Products in Database</response>
		/// <response code="400">
		/// When a request error occurs but a message reporting the error is returned
		/// </response>
		[HttpGet("page/{page}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> Get([FromRoute] int page)
		{
			_logger.LogInformation("Begin Request for all Products {page}", page);
			return ServiceResponse(await _mediator.Send(new GetAllDashboard { page = page }));
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
		[HttpGet("top-5")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> Get()
		{
			_logger.LogInformation("Begin Request for top 5 most sold products)");
			return ServiceResponse(await _mediator.Send(new GetTopFive { }));
		}
	}
}