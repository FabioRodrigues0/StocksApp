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
	public class GetAllDashboardHandler : ValidationsBase<ProductsMovement>, IRequestHandler<GetAllDashboard, PagesProductsModel>
	{
		private readonly IDashBoardRepository _dashboardRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<GetAllDashboardHandler> _logger;

		public GetAllDashboardHandler(
			IDashBoardRepository dashboardRepository,
			IServiceContext serviceContext,
			IMapper mapper,
			ILogger<GetAllDashboardHandler> logger) : base(logger, serviceContext)
		{
			_dashboardRepository = dashboardRepository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<PagesProductsModel> Handle(GetAllDashboard request, CancellationToken cancellationToken)
		{
			var result = await _dashboardRepository.GetAllAsync(request.page, request.itemsPerPage);
			if (result.Models.Count == 0)
			{
				_logger.LogInformation("No Content");
				NoContent(false);
			}
			return _mapper.Map<PagesProductsModel>(result);
		}
	}
}