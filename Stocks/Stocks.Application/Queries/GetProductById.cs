using System;
using MediatR;
using Stock.Application.Models;

namespace Stock.Application.Queries
{
	public sealed class GetProductById : IRequest<ProductsMovementModel>
	{
		public Guid Id { get; set; }
	}
}