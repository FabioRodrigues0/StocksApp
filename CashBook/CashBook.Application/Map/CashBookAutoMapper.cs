using AutoMapper;
using CashBook.Application.DTO;
using CashBook.Domain.Models;

namespace CashBook.Application.Map;

public class CashBookAutoMapper : Profile
{
	public CashBookAutoMapper()
	{
		CreateMap<CashBooks, CashBookDto>().ReverseMap();
		CreateMap<CashBooks, CashBookUpdateDto>().ReverseMap();
		CreateMap<(List<CashBooks> list, int totalPages, int page), (List<CashBookDto> list, int totalPages, int page)>().ReverseMap();
	}
}