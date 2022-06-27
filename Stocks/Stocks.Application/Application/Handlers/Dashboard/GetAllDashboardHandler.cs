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
	public class GetAllDashboardHandler : ValidationsBase<ProductsMovement>, IRequestHandler<GetAllDashboard, PagesProductsDto>
	{
		private readonly IProductsMovementRepository _productsRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<GetAllDashboardHandler> _logger;

		public GetAllDashboardHandler(
			IProductsMovementRepository productsRepository,
			IServiceContext serviceContext,
			IMapper mapper,
			ILogger<GetAllDashboardHandler> logger) : base(logger, serviceContext)
		{
			_productsRepository = productsRepository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<PagesProductsDto> Handle(GetAllDashboard request, CancellationToken cancellationToken)
		{
			var result = await _productsRepository.GetAllAsync(request.page);
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