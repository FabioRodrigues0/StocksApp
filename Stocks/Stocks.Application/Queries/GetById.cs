using System;
using MediatR;
using Stock.Application.DTO;

namespace Stock.Application.Queries
{
	public sealed class GetById : IRequest<MovementsDto>
	{
		public Guid Id { get; set; }
	}
}