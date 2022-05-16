using CashBook.Domain.Models;
using Infrastructure.Shared.Interfaces;

namespace CashBook.Data.Repositories.Interfaces;

public interface ICashBookRepository : IRepositoryBase<CashBooks>
{
	Task<List<CashBooks>> GetByOriginId(Guid id);
}