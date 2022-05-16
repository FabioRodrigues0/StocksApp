using FinancialApp.Domain.Models;
using FinancialApp.Shared.Interfaces;

namespace CashBook.Service.Interface;

public interface ICashBookService : IServiceBase<CashBook>
{
	Task<List<CashBook>> GetByOriginId(Guid id);
}