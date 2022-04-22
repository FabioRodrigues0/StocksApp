using FinacialApp.Domain.Models;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Interfaces;

public interface ICashBookMapper
{
	#region Mappers

	CashBook MapperToEntity(CashBookDto cashBookDto);

	PagesCashBookDto MapperListCashBook(List<CashBook> cashBook, int page);

	CashBookDto MapperToDTO(CashBook cashBook);

	#endregion Mappers
}