using MediatR;
using Stock.Application.DTO;

namespace Stock.Application.Queries
{
	public class GetTopFive : IRequest<PagesProductsDto>
	{
	}
}