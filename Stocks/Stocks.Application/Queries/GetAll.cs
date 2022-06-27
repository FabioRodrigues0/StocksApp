using MediatR;
using Stock.Application.DTO;

namespace Stock.Application.Queries
{
	public class GetAll : IRequest<PagesMovementsDto>
	{
		public int page { get; set; }
	}
}