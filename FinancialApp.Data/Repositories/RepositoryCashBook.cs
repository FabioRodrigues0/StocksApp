using FinacialApp.Data;
using FinacialApp.Domain.Models;
using FinancialApp.Domain.Core.Repositories;

namespace FinancialApp.Data;

public class RepositoryCashBook : RepositoryBase<CashBook>, IRepositoryCashBook
{
	private readonly DataContext _dataContext;

	public RepositoryCashBook(DataContext dataContext)
		: base(dataContext)
	{
		_dataContext = dataContext;
	}
}