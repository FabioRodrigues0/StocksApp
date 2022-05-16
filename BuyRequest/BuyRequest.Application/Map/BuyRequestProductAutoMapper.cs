using AutoMapper;
using BuyRequest.Application.DTO;
using BuyRequest.Domain.Models;

namespace BuyRequest.Application.Map;

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