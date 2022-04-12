using FinacialApp.Domain.Models;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Core.Services;
using FinancialApp.Shared;

namespace FinancialApp.Domain.Services.Services;

public class ServiceCashBook : ServiceBase<CashBook>, IServiceCashBook
{
	private readonly IRepositoryCashBook repositoryCashBook;

	public ServiceCashBook(IRepositoryCashBook repositoryCashBook)
		: base(repositoryCashBook)
	{
		this.repositoryCashBook = repositoryCashBook;
	}
}