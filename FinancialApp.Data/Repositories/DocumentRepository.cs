using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Models;
using FinancialApp.DTO.DTO;
using FinancialApp.Shared;
using FinancialApp.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace FinancialApp.Data.Repositories;

public class DocumentRepository : RepositoryBase<Document>, IDocumentRepository
{
	private readonly HttpClient _http;

	public DocumentRepository(DataContext context, HttpClient http) : base(context)
	{
		_http = http;
	}

	public override async Task<Document> Add(Document obj)
	{
		await base.Add(obj);
		if(obj.Paid)
		{
			var result = new CashBookDto
			{
				Origin = Origin.Document,
				OriginId = obj.Id,
				Description = "Document nº" + obj.Number,
				Type = obj.Operation == Operation.Input ? StatusCashBook.Payment : StatusCashBook.Receivement,
				Valor = obj.Total
			};
			await _http.PostAsJsonAsync("https://localhost:7063/api/CashBook", result);
		}
		return obj;
	}

	public override async Task<Document> Remove(Guid id)
	{
		var result = await dbSet
				.Where(x => x.Id == id)
				.AsNoTracking()
				.FirstOrDefaultAsync();
		await base.Remove(id);
		if(result.Paid)
		{
			var cashBook = new CashBookDto
			{
				Origin = Origin.Document,
				OriginId = result.Id,
				Description = "Document nº" + result.Number,
				Type = StatusCashBook.Reversal,
				Valor = result.Total
			};
			await _http.PostAsJsonAsync("https://localhost:7063/api/CashBook", cashBook);
		}
		return result;
	}

	public override async Task<Document> Update(Document obj)
	{
		var result = await dbSet
			.Where(x => x.Id == obj.Id)
			.AsNoTracking()
			.FirstOrDefaultAsync();
		await base.Update(obj);
		if(obj.Paid)
		{
			var cashBook = new CashBookDto
			{
				Origin = Origin.Document,
				OriginId = obj.Id,
				Description = "Document nº" + obj.Number,
				Type = StatusCashBook.Reversal,
				Valor = result.Total - obj.Total
			};
			await _http.PostAsJsonAsync("https://localhost:7063/api/CashBook", cashBook);
		}
		return obj;
	}

	public virtual async Task<Document> Patch(Document obj)
	{
		var result = await dbSet
			.Where(x => x.Id == obj.Id)
			.AsNoTracking()
			.FirstOrDefaultAsync();
		result.Paid = obj.Paid;
		await base.Patch(result);
		if(obj.Paid)
		{
			var cashBook = new CashBookDto
			{
				Origin = Origin.Document,
				OriginId = result.Id,
				Description = "Document nº" + result.Number,
				Type = StatusCashBook.Reversal,
				Valor = result.Total
			};
			await _http.PostAsJsonAsync("https://localhost:7063/api/CashBook", cashBook);
		}
		return result;
	}
}