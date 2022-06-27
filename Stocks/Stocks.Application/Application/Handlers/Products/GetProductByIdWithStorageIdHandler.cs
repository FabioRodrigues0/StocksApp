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

namespace Stock.Application.Application.Handlers.Products
{
	public sealed class GetProductByIdWithStorageIdHandler : ValidationsBase<ProductsMovement>, IRequestHandler<GetProductByIdWithStorageId, ProductsMovementDto>
	{
		private readonly IProductsMovementRepository _productsRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<GetProductByIdWithStorageIdHandler> _logger;

		public GetProductByIdWithStorageIdHandler(
			IProductsMovementRepository productsRepository,
			IMapper mapper,
			IServiceContext serviceContext,
			ILogger<GetProductByIdWithStorageIdHandler> logger) : base(logger, serviceContext)
		{
			_productsRepository = productsRepository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<ProductsMovementDto> Handle(GetProductByIdWithStorageId request, CancellationToken cancellationToken)
		{
			var result = await _productsRepository.GetByIdWithStorageIdAsync(request.Id, request.StorageId);
			if (result == null)
			{
				_logger.LogInformation("No Content");
				NoContent(false);
			}
			return _mapper.Map<ProductsMovementDto>(result);
		}
	}
}