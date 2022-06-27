using System;
using MediatR;
using Stock.Application.DTO;

namespace Stock.Application.Queries
{
	public sealed class GetProductById : IRequest<ProductsMovementDto>
	{
		public Guid Id { get; set; }
	}
}