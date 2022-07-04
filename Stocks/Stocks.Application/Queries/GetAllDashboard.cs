using MediatR;
using Stock.Application.Models;

namespace Stock.Application.Queries
{
	public class GetAllDashboard : IRequest<PagesProductsModel>
	{
		public int page { get; set; }
		public int itemsPerPage { get; set; }
	}
}