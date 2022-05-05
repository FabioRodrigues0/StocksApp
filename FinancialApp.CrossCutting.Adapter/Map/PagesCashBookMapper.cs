using AutoMapper;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Map;

public class PagesCashBookMapper : Profile
{
	public PagesCashBookMapper()
	{
		CreateMap<List<CashBookDto>, PagesCashBookDto>()
				.ForMember(to => to.Models, from => from.MapFrom(x => x))
				.ForMember(to => to.CurrentPage, from => from.Ignore())
				.ForMember(to => to.Pages, from => from.Ignore())
				.ForMember(to => to.Total, from => from.MapFrom(x => x.Sum(t => t.Valor)));
	}
}