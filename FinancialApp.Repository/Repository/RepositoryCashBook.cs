using FinacialApp.Data;
using FinacialApp.Domain.Models;
using FinancialApp.Data;
using FinancialApp.Domain.Core.Repositories;

namespace FinancialApp.Repository.Repository;

public class RepositoryCashBook : RepositoryBase<CashBook>, IRepositoryCashBook
{
	public readonly HttpClient Http;

	public RepositoryCashBook(DataContext context, HttpClient http) : base(context)
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