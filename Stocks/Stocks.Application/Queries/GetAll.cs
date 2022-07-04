using MediatR;
using Stock.Application.Models;

namespace Stock.Application.Queries
{
	public class GetAll : IRequest<PagesMovementsModel>
	{
		public int page { get; set; }
		public int itemsPerPage { get; set; }
	}
}