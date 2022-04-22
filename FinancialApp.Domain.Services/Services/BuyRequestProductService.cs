using FinacialApp.Domain.Models;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Core.Services;
using FinancialApp.Shared;

namespace FinancialApp.Domain.Services.Services;

public class BuyRequestProductService : ServiceBase<BuyRequestProducts>, IBuyRequestProductService
{
	private readonly IBuyRequestProductsRepository _buyRequestProductsRepository;

	public BuyRequestProductService(IBuyRequestProductsRepository buyRequestProductsRepository)
		: base(buyRequestProductsRepository)
	{
		_buyRequestProductsRepository = buyRequestProductsRepository;
	}
}