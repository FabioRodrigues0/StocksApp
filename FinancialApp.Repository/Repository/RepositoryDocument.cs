using FinacialApp.Data;
using FinacialApp.Domain.Models;
using FinacialApp.Shared;
using FinancialApp.Data;
using FinancialApp.Domain.Core.Repositories;
using System.Net.Http.Json;
using System.Text;
using Microsoft.AspNetCore.JsonPatch;

namespace FinancialApp.Repository.Repository;

public class RepositoryDocument : RepositoryBase<Document>, IRepositoryDocument
{
	private readonly HttpClient _http;

	public RepositoryDocument(DataContext context, HttpClient http) : base(context)
	{
		_http = http;
	}

	public override async Task Add(Document obj)
	{
		try
		{
			await base.Add(obj);
			if(obj.isPaid)
			{
				var result = new CashBook()
				{
					Id = Guid.NewGuid(),
					Origin = Origin.Document,
					OriginId = obj.Id,
					Description = "Document nº" + obj.Number,
					Type = obj.Operation == Operation.Input ? StatusCashBook.Payment : StatusCashBook.Receivement,
					Valor = obj.Total
				};
				await _http.PostAsJsonAsync("https://localhost:7063/api/CashBook", result);
			}
		}
		catch(Exception ex)
		{
			throw ex;
		}
	}

	public override async Task Remove(Document obj)
	{
		try
		{
			await base.Remove(obj);
			if(obj.isPaid)
			{
				var result = new CashBook()
				{
					Id = Guid.NewGuid(),
					Origin = Origin.Document,
					OriginId = obj.Id,
					Description = "Document nº" + obj.Number,
					Type = StatusCashBook.Reversal,
					Valor = obj.Total
				};
				await _http.PostAsJsonAsync("https://localhost:7063/api/CashBook", result);
			}
		}
		catch(Exception ex)
		{
			throw ex;
		}
	}

	public override async Task Update(Document obj)
	{
		try
		{
			await base.Update(obj);
			if(obj.isPaid)
			{
				var result = new CashBook()
				{
					Id = Guid.NewGuid(),
					Origin = Origin.Document,
					OriginId = obj.Id,
					Description = "Document nº" + obj.Number,
					Type = StatusCashBook.Reversal,
					Valor = obj.Total
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