using FinacialApp.Domain.Models;
using FinancialApp.Domain.Core.Repositories;

namespace FinancialApp.Data.Repositories;

public class CashBookRepository : RepositoryBase<CashBook>, ICashBookRepository
{
	public readonly HttpClient Http;

	public CashBookRepository(DataContext context, HttpClient http) : base(context)
	{
		Http = http;
	}

	public CashBook GetById(Guid id)
	{
		var resultOrigin = dbSet.Where(c => c.OriginId == id).FirstOrDefault();
		var resultId = dbSet.Find(id);

		if(resultId != null)
			return resultId;
		else
			return resultOrigin;
	}
}