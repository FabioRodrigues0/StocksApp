using MediatR;
using Stock.Application.DTO;

namespace Stock.Application.Queries
{
	public class GetAllDashboard : IRequest<PagesProductsDto>
	{
		public int page { get; set; }
	}
}