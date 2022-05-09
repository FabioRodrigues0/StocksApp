using FinancialApp.Domain.Models;
using FinancialApp.DTO.DTO;

namespace FinancialApp.Application.Interface;

public interface IApplicationCashBookService
{
	Task<CashBook> Add(CashBookDto obj);

	Task<CashBookDto> GetById(Guid id);

	Task<List<CashBookDto>> GetByOriginId(Guid id);

	Task<PagesCashBookDto> GetAll(int page);

	Task<CashBook> Update(CashBookUpdateDto obj);
}