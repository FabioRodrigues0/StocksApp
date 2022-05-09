using AutoMapper;
using FinancialApp.Domain.Models;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Map;

public class CashBookAutoMapper : Profile
{
	public CashBookAutoMapper()
	{
		CreateMap<CashBook, CashBookDto>().ReverseMap();
		CreateMap<CashBook, CashBookUpdateDto>().ReverseMap();
	}
}