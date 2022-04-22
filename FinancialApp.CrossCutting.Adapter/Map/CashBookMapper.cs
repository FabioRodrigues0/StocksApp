using FinacialApp.Domain.Models;
using FinancialApp.Shared;
using FinancialApp.CrossCutting.Adapter.Interfaces;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Map;

public class CashBookMapper : ICashBookMapper
{
	#region properties

	private readonly List<CashBookDto> _cashBookDtos = new List<CashBookDto>();
	private readonly PagesCashBookDto _TotalcashBookDtos = new PagesCashBookDto();
	private decimal totalCashBook;

	#endregion properties

	#region methods

	public CashBook MapperToEntity(CashBookDto cashBookDto)
	{
		CashBook cashBook = new CashBook()
		{
			Id = Guid.NewGuid(),
			Origin = cashBookDto.Origin,
			OriginId = cashBookDto.OriginId,
			Description = cashBookDto.Description,
			Type = cashBookDto.Type,
			Valor = cashBookDto.Valor
		};
		return cashBook;
	}

	public PagesCashBookDto MapperListCashBook(List<CashBook> cashBook, int page)
	{
		var pageResults = 3f;
		var pageCount = Math.Ceiling(cashBook.Count() / pageResults);

		foreach(var cb in cashBook)
		{
			CashBookDto cashBookDto = new CashBookDto
			{
				Origin = cb.Origin,
				OriginId = cb.OriginId,
				Description = cb.Description,
				Type = cb.Type,
				Valor = cb.Valor,
			};
			totalCashBook += cb.Valor;
			_cashBookDtos.Add(cashBookDto);
		}

		_TotalcashBookDtos.Models = _cashBookDtos;
		_TotalcashBookDtos.CurrentPage = page;
		_TotalcashBookDtos.Pages = (int)pageCount;
		_TotalcashBookDtos.Total = totalCashBook;
		return _TotalcashBookDtos;
	}

	public CashBookDto MapperToDTO(CashBook cashBook)
	{
		CashBookDto cashBookDto = new CashBookDto
		{
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