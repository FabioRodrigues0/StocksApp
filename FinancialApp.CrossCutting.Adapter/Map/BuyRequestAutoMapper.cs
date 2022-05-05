using AutoMapper;
using FinancialApp.Domain.Models;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Map;

public class BuyRequestAutoMapper : Profile
{
	public BuyRequestAutoMapper()
	{
		CreateMap<BuyRequestDto, BuyRequest>()
			.ForMember(to => to.ProductValor, from => from.MapFrom(x => x.Products.Sum(x => x.Quantity * x.Valor)))
			.ForMember(to => to.Cost, from => from.MapFrom(x => x.Products.Sum(x => x.Quantity * x.Valor)))
			.ForMember(to => to.TotalValor, from => from.MapFrom(x => (x.Products.Sum(x => x.Quantity * x.Valor) - x.Discount)))
			.ReverseMap();
		CreateMap<BuyRequestUpdateDto, BuyRequest>()
			.ForMember(to => to.ProductValor, from => from.MapFrom(x => x.Products.Sum(x => x.Quantity * x.Valor)))
			.ForMember(to => to.Cost, from => from.MapFrom(x => x.Products.Sum(x => x.Quantity * x.Valor)))
			.ForMember(to => to.TotalValor, from => from.MapFrom(x => (x.Products.Sum(x => x.Quantity * x.Valor) - x.Discount)))
			.ReverseMap();
		CreateMap<BuyRequestPatchDto, BuyRequest>()
			.ForMember(to => to.ProductValor, from => from.UseDestinationValue())
			.ForMember(to => to.Cost, from => from.UseDestinationValue())
			.ForMember(to => to.TotalValor, from => from.UseDestinationValue())
			.ReverseMap();
	}
}