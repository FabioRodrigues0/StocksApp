using FinacialApp.Data;
using FinacialApp.Domain.Models;
using FinancialApp.Domain.Core.Repositories;

namespace FinancialApp.Repository.Repository;

public class RepositoryBuyRequest : RepositoryBase<BuyRequest>, IRepositoryBuyRequest
{
	private readonly DataContext _context;

	public RepositoryBuyRequest(DataContext context) : base(context)
	{
		_context = context;
	}
}