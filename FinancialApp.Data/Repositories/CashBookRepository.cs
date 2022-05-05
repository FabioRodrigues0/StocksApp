using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Models;
using FinancialApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace FinancialApp.Data.Repositories;

public class CashBookRepository : RepositoryBase<CashBook>, ICashBookRepository
{
	public readonly HttpClient Http;

	public CashBookRepository(DataContext context, HttpClient http) : base(context)
	{
		Http = http;
	}

	public CashBook GetById(Guid id)
	{
		var result = dbSet.Where(c => c.OriginId == id || c.Id == id).FirstOrDefault();
		return result;
	}

	public override async Task<CashBook> Update(CashBook obj)
	{
		var result = dbSet.Find(obj.Id);
		result.Id = obj.Id;
		result.OriginId = obj.OriginId;
		result.Description = obj.Description;
		result.Type = obj.Type;
		result.Valor = obj.Valor;
		_dataContext.Update(result);
		await _dataContext.SaveChangesAsync();
		return obj;
	}

	public async Task<List<CashBook>> GetByOriginId(Guid id)
	{
		var result = await dbSet
			.AsNoTracking()
			.ToListAsync();
		result.Select(c => c.OriginId == id);
		return result;
	}
}