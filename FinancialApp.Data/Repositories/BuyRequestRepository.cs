using FinacialApp.Domain.Models;
using FinancialApp.Data.Repositories;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.DTO.DTO;
using FinancialApp.Shared;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using FinancialApp.Domain.Models;

namespace FinancialApp.Data;

public class BuyRequestRepository : RepositoryBase<BuyRequest>, IBuyRequestRepository
{
	private readonly HttpClient _http;

	public BuyRequestRepository(DataContext context, HttpClient http) : base(context)
	{
		_http = http;
		dbSet.Include(i => i.Products);
	}

	public async Task<BuyRequest> GetById(Guid id)
	{
		var resultClient = await dbSet.Where(br => br.Client == id).FirstOrDefaultAsync();
		var resultId = await dbSet.FindAsync(id);

		if(resultId != null)
			return resultId;
		else
			return resultClient;
	}

	public override async Task Add(BuyRequest obj)
	{
		try
		{
			await base.Add(obj);
			if(Status.Finished.Equals(obj.Status))
			{
				var result = new CashBookDto()
				{
					Origin = Origin.BuyRequest,
					OriginId = obj.Id,
					Description = "Buy Request nº" + obj.Code,
					Type = StatusCashBook.Payment,
					Valor = obj.TotalValor
				};
				await _http.PostAsJsonAsync("https://localhost:7063/api/CashBook", result);
			}
		}
		catch(Exception e)
		{
			throw e;
		}
	}

	public override async Task Remove(BuyRequest obj)
	{
		try
		{
			await base.Remove(obj);
			if(obj.Status == Status.Finished)
			{
				var result = new CashBook()
				{
					Id = Guid.NewGuid(),
					Origin = Origin.BuyRequest,
					OriginId = obj.Id,
					Description = "Buy Request nº" + obj.Code,
					Type = StatusCashBook.Reversal,
					Valor = obj.TotalValor
				};
				await _http.PostAsJsonAsync("https://localhost:7063/api/CashBook", result);
			}
		}
		catch(Exception ex)
		{
			throw ex;
		}
	}

	public override async Task Update(BuyRequest obj)
	{
		try
		{
			await base.Update(obj);
			if(obj.Status == Status.Finished)
			{
				var result = new CashBook()
				{
					Id = Guid.NewGuid(),
					Origin = Origin.BuyRequest,
					OriginId = obj.Id,
					Description = "Buy Request nº" + obj.Code,
					Type = StatusCashBook.Reversal,
					Valor = obj.TotalValor
				};
				await _http.PostAsJsonAsync("https://localhost:7063/api/CashBook", result);
			}
		}
		catch(Exception ex)
		{
			throw ex;
		}
	}
}