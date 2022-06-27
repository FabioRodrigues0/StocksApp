using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Shared.Services;
using Infrastructure.Shared.Services.Interface;
using MediatR;
using Microsoft.Extensions.Logging;
using Stock.Application.DTO;
using Stock.Application.Queries;
using Stock.Data.Repositories.Interfaces;
using Stock.Domain.Models;

namespace Stock.Application.Application.Handlers.Dashboard
{
	public class GetTopFiveHandler : ValidationsBase<ProductsMovement>, IRequestHandler<GetTopFive, PagesProductsDto>
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

		public async Task<PagesProductsDto> Handle(GetTopFive request, CancellationToken cancellationToken)
		{
			var result = await _dashboardRepository.GetBestSellers();
			if (result.list.Count == 0)
			{
				_logger.LogInformation("No Content");
				NoContent(false);
			}
			var toPages = _mapper.Map<(List<ProductsMovementDto> list, int totalPages, int page)>(result);
			return _mapper.Map<PagesProductsDto>(toPages);
		}
	}
}