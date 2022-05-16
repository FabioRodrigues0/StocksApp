using BuyRequest.Service.Interface;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Models;
using FinancialApp.Shared;
using FinancialApp.Shared.Interfaces;

namespace BuyRequest.Service;

public class BuyRequestProductService : ServiceBase<BuyRequestProducts>, IBuyRequestProductService
{
	private readonly IBuyRequestProductsRepository _buyRequestProductsRepository;

	public BuyRequestProductService(
		IServiceContext serviceContext,
		IBuyRequestProductsRepository buyRequestProductsRepository)
		: base(buyRequestProductsRepository, serviceContext)
	{
		_buyRequestProductsRepository = buyRequestProductsRepository;
	}
}