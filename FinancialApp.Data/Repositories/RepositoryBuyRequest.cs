using FinacialApp.Data;
using FinacialApp.Domain.Models;
using FinancialApp.Domain.Core.Repositories;

namespace FinancialApp.Data;

public class RepositoryBuyRequest : RepositoryBase<BuyRequest>, IRepositoryBuyRequest
{
	private readonly DataContext _dataContext;

	public RepositoryBuyRequest(DataContext dataContext)
		: base(dataContext)
	{
		_dataContext = dataContext;
	}
}