using FinacialApp.Domain.Models;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Shared;
using System.Net.Http.Json;
using FinancialApp.Data.Repositories;

namespace FinancialApp.Data;

public class DocumentRepository : RepositoryBase<Document>, IDocumentRepository
{
	private readonly HttpClient _http;

	public DocumentRepository(DataContext context, HttpClient http) : base(context)
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