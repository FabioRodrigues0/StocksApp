using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Models;
using FinancialApp.DTO.DTO;
using FinancialApp.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace FinancialApp.Data.Repositories;

public class BuyRequestRepository : RepositoryBase<BuyRequest>, IBuyRequestRepository
{
	private readonly HttpClient _http;
	private readonly IBuyRequestProductsRepository _productsRepository;

	public BuyRequestRepository(DataContext context, HttpClient http, IBuyRequestProductsRepository productsRepository) : base(context)
	{
		_http = http;
		_productsRepository = productsRepository;
		SetInclude(x => x.Include(z => z.Products));
	}

	public override async Task<BuyRequest> Add(BuyRequest obj)
	{
		dbSet.AddAsync(obj);
		await _dataContext.SaveChangesAsync();
		if (Status.Finished.Equals(obj.Status))
		{
			var result = new CashBookDto
			{
				Origin = Origin.BuyRequest,
				OriginId = obj.Id,
				Description = "Buy Request nº" + obj.Code,
				Type = StatusCashBook.Payment,
				Valor = obj.TotalValor,
				IsEdited = true
			};
			await _http.PostAsJsonAsync("https://localhost:7063/api/CashBook", result);
		}
		return obj;
	}

	public override async Task<BuyRequest> GetById(Guid id)
	{
		var query = dbSet.Where(br => br.Client == id || br.Id == id);
		if (Include != null)
			query = Include(query);
		return await query.AsNoTracking().FirstOrDefaultAsync();
	}

	public virtual async Task<BuyRequest> Patch(BuyRequest obj)
	{
		var result = await dbSet
			.Where(x => x.Id == obj.Id)
			.AsNoTracking()
			.FirstOrDefaultAsync();
		result.Status = obj.Status;
		await base.Patch(result);
		if (obj.Status == Status.Finished)
		{
			var cashBook = new CashBookDto
			{
				Origin = Origin.BuyRequest,
				OriginId = result.Id,
				Description = "Buy Request nº" + result.Code,
				Type = StatusCashBook.Reversal,
				Valor = result.TotalValor,
				IsEdited = true
			};
			await _http.PostAsJsonAsync("https://localhost:7063/api/CashBook", cashBook);
		}
		return result;
	}

	public override async Task<BuyRequest> Remove(Guid id)
	{
		var result = await dbSet
			.Where(x => x.Id == id)
			.AsNoTracking()
			.FirstOrDefaultAsync();
		await base.Remove(id);
		if (result.Status == Status.Finished)
		{
			var cashBook = new CashBookDto
			{
				Origin = Origin.BuyRequest,
				OriginId = result.Id,
				Description = "Buy Request nº" + result.Code,
				Type = StatusCashBook.Reversal,
				Valor = result.TotalValor,
				IsEdited = true
			};
			await _http.PostAsJsonAsync("https://localhost:7063/api/CashBook", cashBook);
		}

		return result;
	}

	public override async Task<BuyRequest> Update(BuyRequest obj)
	{
		var result = await dbSet
			.Where(x => x.Id == obj.Id)
			.Include(i => i.Products)
			.AsNoTracking()
			.FirstOrDefaultAsync();

		var productsIds = obj.Products.Select(s => s.Id).ToList();
		var productsToDelete = result.Products.Where(w => !productsIds.Contains(w.Id)).ToList();
		foreach (var produto in productsToDelete)
		{
			await _productsRepository.Remove(produto.Id);
		}

		await base.Update(obj);
		if (obj.Status == Status.Finished)
		{
			var cashBook = new CashBookDto
			{
				Origin = Origin.BuyRequest,
				OriginId = obj.Id,
				Description = "Buy Request nº" + obj.Code,
				Type = StatusCashBook.Reversal,
				Valor = obj.TotalValor - result.TotalValor,
				IsEdited = true
			};
			await _http.PostAsJsonAsync("https://localhost:7063/api/CashBook", cashBook);
		}
		return obj;
	}
}