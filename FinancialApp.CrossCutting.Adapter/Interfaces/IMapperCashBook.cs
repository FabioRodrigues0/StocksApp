using FinacialApp.Domain.Models;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Interfaces;

public interface IMapperCashBook
{
	#region Mappers

	CashBook MapperToEntity(CashBookDTO cashBookDto);

	IEnumerable<CashBookDTO> MapperListCashBook(IEnumerable<CashBook> cashBook);

	CashBookDTO MapperToDTO(CashBook cashBook);

	#endregion Mappers
}