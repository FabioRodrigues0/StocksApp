#region Imports

using MediatR;
using Stock.Application.Models;
using Stock.Domain.Entities;

#endregion

namespace Stock.Application.Commands
{
	public class Post : IRequest<Movements>
	{
		public MovementsModel Movements { get; set; }
	}
}