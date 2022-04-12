using FinacialApp.Data;
using FinacialApp.Domain.Models;
using FinancialApp.Domain.Core.Repositories;

namespace FinancialApp.Repository.Repository;

public class RepositoryCashBook : RepositoryBase<CashBook>, IRepositoryCashBook
{
	private readonly DataContext _context;

	public RepositoryCashBook(DataContext context) : base(context)
	{
		_context = context;
	}
}