using FinacialApp.Domain.Models;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Core.Services;
using FinancialApp.Domain.Models;
using FinancialApp.Shared;

namespace FinancialApp.Domain.Services.Services;

public class BuyRequestService : ServiceBase<BuyRequest>, IBuyRequestService
{
	private readonly IBuyRequestRepository _buyRequestRepository;

	public BuyRequestService(IBuyRequestRepository buyRequestRepository)
		: base(buyRequestRepository)
	{
		this._buyRequestRepository = buyRequestRepository;
	}
}