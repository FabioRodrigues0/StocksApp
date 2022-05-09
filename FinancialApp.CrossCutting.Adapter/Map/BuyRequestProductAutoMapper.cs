using AutoMapper;
using FinancialApp.Domain.Models;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Map;

public class BuyRequestProductAutoMapper : Profile
{
	public BuyRequestProductAutoMapper()
	{
		CreateMap<BuyRequestProductDto, BuyRequestProducts>()
			.ForMember(to => to.Total, from => from.MapFrom(x => x.Valor * x.Quantity))
			.ReverseMap();
		CreateMap<BuyRequestProductUpdateDto, BuyRequestProducts>()
			.ForMember(to => to.Total, from => from.MapFrom(x => x.Valor * x.Quantity))
			.ReverseMap();
	}
}