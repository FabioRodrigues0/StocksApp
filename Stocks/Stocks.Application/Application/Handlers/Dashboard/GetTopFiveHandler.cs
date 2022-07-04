using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Shared.Services;
using Infrastructure.Shared.Services.Interface;
using MediatR;
using Microsoft.Extensions.Logging;
using Stock.Application.Models;
using Stock.Application.Queries;
using Stock.Data.Repositories.Interfaces;
using Stock.Domain.Entities;

namespace Stock.Application.Application.Handlers.Dashboard
{
	public class GetTopFiveHandler : ValidationsBase<ProductsMovement>, IRequestHandler<GetTopFive, PagesProductsModel>
	{
		private readonly IDashBoardRepository _dashboardRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<GetTopFiveHandler> _logger;

		public GetTopFiveHandler(
			IDashBoardRepository productsRepository,
			IServiceContext serviceContext,
			IMapper mapper,
			ILogger<GetTopFiveHandler> logger) : base(logger, serviceContext)
		{
			_dashboardRepository = productsRepository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<PagesProductsModel> Handle(GetTopFive request, CancellationToken cancellationToken)
		{
			var result = await _dashboardRepository.GetBestSellers();
			if (result.Models.Count == 0)
			{
				_logger.LogInformation("No Content");
				NoContent(false);
			}
			return _mapper.Map<PagesProductsModel>(result);
		}
	}
}