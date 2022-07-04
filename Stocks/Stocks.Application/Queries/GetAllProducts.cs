using MediatR;
using Stock.Application.Models;

namespace Stock.Application.Queries
{
	public class GetAllProducts : IRequest<PagesProductsModel>
	{
		public int page { get; set; }
		public int itemsPerPage { get; set; }
	}
}