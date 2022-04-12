using FinacialApp.Domain.Models;
using FinacialApp.Shared;
using FinancialApp.CrossCutting.Adapter.Interfaces;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Map;

public class MapperCashBook : IMapperCashBook
{
	#region properties

	private readonly List<CashBookDTO> _cashBookDtos = new List<CashBookDTO>();

	#endregion properties

	#region methods

	public CashBook MapperToEntity(CashBookDTO cashBookDto)
	{
		CashBook cashBook = new CashBook()
		{
			Id = cashBookDto.Id,
			Origin = cashBookDto.Origin,
			OriginId = cashBookDto.OriginId,
			Description = cashBookDto.Description,
			Type = cashBookDto.Type,
			Valor = cashBookDto.Valor
		};
		return cashBook;
	}

	public IEnumerable<CashBookDTO> MapperListCashBook(IEnumerable<CashBook> cashBook)
	{
		foreach(var cb in cashBook)
		{
			CashBookDTO cashBookDto = new CashBookDTO
			{
				Id = cb.Id,
				Origin = cb.Origin,
				OriginId = cb.OriginId,
				Description = cb.Description,
				Type = cb.Type,
				Valor = cb.Valor
			};
			_cashBookDtos.Add(cashBookDto);
		}
		return _cashBookDtos;
	}

	public CashBookDTO MapperToDTO(CashBook cashBook)
	{
		CashBookDTO cashBookDto = new CashBookDTO
		{
			Id = cashBook.Id,
			Origin = cashBook.Origin,
			OriginId = cashBook.OriginId,
			Description = cashBook.Description,
			Type = cashBook.Type,
			Valor = cashBook.Valor
		};
		return cashBookDto;
	}

	#endregion methods
}