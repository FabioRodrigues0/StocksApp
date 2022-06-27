using System.Collections.Generic;
using AutoMapper;
using Stock.Application.DTO;

namespace Stock.Application.Map
{
	public class PagesMapper : Profile
	{
		public PagesMapper()
		{
			CreateMap<(List<MovementsDto> list, int totalPages, int page), PagesMovementsDto>()
			.ForMember(to => to.Models, from => from.MapFrom(x => x.list))
			.ForMember(to => to.CurrentPage, from => from.MapFrom(x => x.page))
			.ForMember(to => to.Pages, from => from.MapFrom(x => x.totalPages));

			CreateMap<(List<ProductsMovementDto> list, int totalPages, int page), PagesProductsDto>()
			.ForMember(to => to.Models, from => from.MapFrom(x => x.list))
			.ForMember(to => to.CurrentPage, from => from.MapFrom(x => x.page))
			.ForMember(to => to.Pages, from => from.MapFrom(x => x.totalPages));
		}
	}
}