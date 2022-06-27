#region Imports

using MediatR;
using Stock.Application.DTO;
using Stock.Domain.Models;

#endregion

namespace Stock.Application.Commands
{
	public class Post : IRequest<Movements>
	{
		public MovementsDto Movements { get; set; }
	}
}