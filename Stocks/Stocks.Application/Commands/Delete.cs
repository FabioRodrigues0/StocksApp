using System;
using MediatR;

namespace Stock.Application.Commands
{
	public class Delete : IRequest<bool>
	{
		public Guid Id { get; set; }
	}
}