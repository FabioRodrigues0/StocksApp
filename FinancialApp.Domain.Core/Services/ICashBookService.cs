using FinancialApp.Domain.Models;
using FinancialApp.Shared.Interfaces;

namespace FinancialApp.Domain.Core.Services;

public interface ICashBookService : IServiceBase<CashBook>
{
	Task<List<CashBook>> GetByOriginId(Guid id);
}