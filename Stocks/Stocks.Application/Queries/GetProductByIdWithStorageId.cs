using System;
using MediatR;
using Stock.Application.Models;

namespace Stock.Application.Queries
{
	public sealed class GetProductByIdWithStorageId : IRequest<ProductsMovementModel>
	{
		public Guid Id { get; set; }
		public Guid StorageId { get; set; }
	}
}