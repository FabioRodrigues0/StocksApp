using FinacialApp.Domain.Models;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Core.Services;
using FinancialApp.Shared;

namespace FinancialApp.Domain.Services.Services;

public class ServiceBuyRequest : ServiceBase<BuyRequest>, IServiceBuyRequest
{
	private readonly IRepositoryBuyRequest repositoryBuyRequest;

	public ServiceBuyRequest(IRepositoryBuyRequest repositoryBuyRequest)
		: base(repositoryBuyRequest)
	{
		this.repositoryBuyRequest = repositoryBuyRequest;
	}
}