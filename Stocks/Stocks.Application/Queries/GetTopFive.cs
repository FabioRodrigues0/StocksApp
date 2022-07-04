using MediatR;
using Stock.Application.Models;

namespace Stock.Application.Queries
{
	public class GetTopFive : IRequest<PagesProductsModel>
	{
	}
}