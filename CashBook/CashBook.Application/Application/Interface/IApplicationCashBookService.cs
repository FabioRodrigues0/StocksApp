using CashBook.Application.DTO;
using CashBook.Domain.Models;

namespace CashBook.Application.Application.Interface;

public interface IApplicationCashBookService
{
	Task<CashBooks> Add(CashBookDto obj);

	Task<CashBookDto> GetById(Guid id);

	Task<List<CashBookDto>> GetByOriginId(Guid id);

	Task<PagesCashBookDto> GetAll(int page);

	Task<CashBooks> Update(CashBookUpdateDto obj);
}