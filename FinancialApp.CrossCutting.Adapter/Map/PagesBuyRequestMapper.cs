using AutoMapper;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Map;

public class PagesBuyRequestMapper : Profile
{
	public PagesBuyRequestMapper()
	{
		CreateMap<List<BuyRequestDto>, PagesBuyRequestDto>()
			.ForMember(to => to.Models, from => from.MapFrom(x => x))
			.ForMember(to => to.CurrentPage, from => from.Ignore())
			.ForMember(to => to.Pages, from => from.Ignore());
	}
}