using AutoMapper;
using CashBook.Application.DTO;
using Document.Domain.Models;
using Infrastructure.Shared.Enums;

namespace Document.Application.Map;

public class CashBookConverterAutoMapper : Profile
{
	public CashBookConverterAutoMapper()
	{
		CreateMap<Documents, CashBookDto>()
			.ForMember(to => to.Origin, from => from.MapFrom(x => Origin.Document))
			.ForMember(to => to.OriginId, from => from.MapFrom(x => x.Id))
			.ForMember(to => to.Description, from => from.MapFrom(x => "Document nº" + x.Number))
			.ForMember(to => to.Type, from => from.MapFrom(x => StatusCashBook.Reversal))
			.ForMember(to => to.Valor, from => from.MapFrom(x => x.Total))
			.ReverseMap();
	}
}