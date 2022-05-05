using FinancialApp.Domain.Models;
using FinancialApp.Shared.Interfaces;

namespace FinancialApp.Domain.Core.Repositories;

public interface ICashBookRepository : IRepositoryBase<CashBook>
{
	Task<List<CashBook>> GetByOriginId(Guid id);
}