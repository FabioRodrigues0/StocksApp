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

namespace Stock.Application.Application.Handlers.Products
{
	public sealed class GetAllProductsHandler : ValidationsBase<ProductsMovement>, IRequestHandler<GetAllProducts, PagesProductsModel>
	{
		private readonly IProductsMovementRepository _productsRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<GetAllProductsHandler> _logger;

		public GetAllProductsHandler(
			IProductsMovementRepository productsRepository,
			IServiceContext serviceContext,
			IMapper mapper,
			ILogger<GetAllProductsHandler> logger) : base(logger, serviceContext)
		{
			_productsRepository = productsRepository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<PagesProductsModel> Handle(GetAllProducts request, CancellationToken cancellationToken)
		{
			var result = await _productsRepository.GetAllAsync(request.page, request.itemsPerPage);
			if (result.Models.Count == 0)
			{
				_logger.LogInformation("No Content");
				NoContent(false);
			}
			return _mapper.Map<PagesProductsModel>(result);
		}
	}
}