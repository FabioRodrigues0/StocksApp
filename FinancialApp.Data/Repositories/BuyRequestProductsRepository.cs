using FinacialApp.Domain.Models;
using FinancialApp.Data.Repositories;
using FinancialApp.Domain.Core.Repositories;

namespace FinancialApp.Data;

public class BuyRequestProductsRepository : RepositoryBase<BuyRequestProducts>, IBuyRequestProductsRepository
{
	private readonly HttpClient _http;

	public BuyRequestProductsRepository(DataContext context, HttpClient http) : base(context)
	{
		_http = http;
	}

	public override List<BuyRequestProducts> GetProducts()
	{
		return dbSet.ToList();
	}
}