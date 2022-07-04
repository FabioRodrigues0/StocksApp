using System;
using MediatR;
using Stock.Application.Models;

namespace Stock.Application.Queries
{
	public sealed class GetById : IRequest<MovementsModel>
	{
		public Guid Id { get; set; }
	}
}