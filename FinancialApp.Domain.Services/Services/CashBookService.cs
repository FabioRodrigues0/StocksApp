using FinacialApp.Domain.Models;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Core.Services;
using FinancialApp.Shared;

namespace FinancialApp.Domain.Services.Services;

public class CashBookService : ServiceBase<CashBook>, ICashBookService
{
	private readonly ICashBookRepository _cashBookRepository;

	public CashBookService(ICashBookRepository cashBookRepository)
		: base(cashBookRepository)
	{
		this._cashBookRepository = cashBookRepository;
	}
}