using FinancialApp.Shared;
using FinancialApp.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace FinancialApp.Data.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase<T>
{
	protected readonly DataContext _dataContext;
	protected readonly DbSet<T> dbSet;
	protected Func<IQueryable<T>, IIncludableQueryable<T, object>> Include;

	public RepositoryBase(DataContext dataContext)
	{
		_dataContext = dataContext;
		dbSet = _dataContext.Set<T>();
	}

	public virtual void SetInclude(Func<IQueryable<T>, IIncludableQueryable<T, object>> include)
	{
		Include = include;
	}

	public virtual async Task<T> Add(T obj)
	{
		try
		{
			await dbSet.AddAsync(obj);
			await _dataContext.SaveChangesAsync();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
		return obj;
	}

	public virtual async Task<List<T>> GetAll()
	{
		var query = dbSet
			.AsNoTracking();

		if (Include != null)
			query = Include(query);

		return await query.ToListAsync();
	}

	public virtual async Task<T> GetById(Guid id)
	{
		var query = dbSet
			.Where(br => br.Id == id)
			.AsNoTracking();

		if (Include != null)
			query = Include(query);

		return await query.FirstOrDefaultAsync();
	}

	public virtual async Task<T> Remove(Guid id)
	{
		var result = await dbSet
			.Where(x => x.Id == id)
			.AsNoTracking()
			.FirstOrDefaultAsync();
		dbSet.Remove(result);
		await _dataContext.SaveChangesAsync();
		return result;
	}

	public virtual async Task<T> Update(T obj)
	{
		dbSet.Update(obj);
		await _dataContext.SaveChangesAsync();
		return obj;
	}

	public virtual async Task<T> Patch(T obj)
	{
		dbSet.Update(obj);
		await _dataContext.SaveChangesAsync();
		return obj;
	}
}