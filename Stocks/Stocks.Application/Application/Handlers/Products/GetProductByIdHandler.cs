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
	public sealed class GetProductByIdHandler : ValidationsBase<ProductsMovement>, IRequestHandler<GetProductById, ProductsMovementModel>
	{
		private readonly IProductsMovementRepository _productsRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<GetProductByIdHandler> _logger;

		public GetProductByIdHandler(
			IProductsMovementRepository productsRepository,
			IMapper mapper,
			IServiceContext serviceContext,
			ILogger<GetProductByIdHandler> logger) : base(logger, serviceContext)
		{
			_productsRepository = productsRepository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<ProductsMovementModel> Handle(GetProductById request, CancellationToken cancellationToken)
		{
			var result = await _productsRepository.GetByIdAsync(request.Id);
			if (result == null)
			{
				_logger.LogInformation("No Content");
				NoContent(false);
			}
			return _mapper.Map<ProductsMovementModel>(result);
		}
	}
}