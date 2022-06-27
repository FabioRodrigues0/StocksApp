using System;
using MediatR;
using Stock.Application.DTO;

namespace Stock.Application.Queries
{
	public sealed class GetProductByIdWithStorageId : IRequest<ProductsMovementDto>
	{
		public Guid Id { get; set; }
		public Guid StorageId { get; set; }
	}
}