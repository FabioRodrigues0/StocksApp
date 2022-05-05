using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Models;

namespace FinancialApp.Data.Repositories;

public class BuyRequestProductsRepository : RepositoryBase<BuyRequestProducts>, IBuyRequestProductsRepository
{
	private readonly HttpClient _http;

	public BuyRequestProductsRepository(DataContext context, HttpClient http) : base(context)
	{
		_http = http;
	}
}