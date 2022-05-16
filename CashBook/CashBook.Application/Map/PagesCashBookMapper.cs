using AutoMapper;
using CashBook.Application.DTO;

namespace CashBook.Application.Map;

public class PagesCashBookMapper : Profile
{
	public PagesCashBookMapper()
	{
		CreateMap<(List<CashBookDto> list, int totalPages, int page), PagesCashBookDto>()
				.ForMember(to => to.Models, from => from.MapFrom(x => x.list))
				.ForMember(to => to.CurrentPage, from => from.MapFrom(x => x.page))
				.ForMember(to => to.Pages, from => from.MapFrom(x => x.totalPages))
				.ForMember(to => to.Total, from => from.MapFrom(x => x.list.Sum(y => y.Valor)));
	}
}