using FinacialApp.Data;
using FinacialApp.Domain.Models;
using FinacialApp.Shared;
using FinancialApp.Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using FinancialApp.Data;
using FinancialApp.DTO.DTO;

namespace FinancialApp.Repository.Repository;

public class RepositoryBuyRequest : RepositoryBase<BuyRequest>, IRepositoryBuyRequest
{
	public readonly HttpClient _http;

	public RepositoryBuyRequest(DataContext context, HttpClient http) : base(context)
	{
		_http = http;
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