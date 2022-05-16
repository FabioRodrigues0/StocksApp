using AutoMapper;
using BuyRequest.Domain.Models;
using CashBook.Application.DTO;
using Infrastructure.Shared.Enums;

namespace BuyRequest.Application.Map;

public class CashBookConverterAutoMapper : Profile
{
	public CashBookConverterAutoMapper()
	{
		CreateMap<BuyRequests, CashBookDto>()
			.ForMember(to => to.Origin, from => from.MapFrom(x => Origin.BuyRequest))
			.ForMember(to => to.OriginId, from => from.MapFrom(x => x.Id))
			.ForMember(to => to.Description, from => from.MapFrom(x => "Buy Request nº" + x.Code))
			.ForMember(to => to.Type, from => from.MapFrom(x => StatusCashBook.Payment))
			.ForMember(to => to.Valor, from => from.MapFrom(x => x.TotalValor))
			.ReverseMap();
	}
}