using FinacialApp.Shared;
using FinancialApp.Shared;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace FinancialApp.Data.Repositories;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
	private readonly DataContext _dataContext;
	protected readonly DbSet<TEntity> dbSet;

	public RepositoryBase(DataContext dataContext)
	{
		_dataContext = dataContext;
		dbSet = _dataContext.Set<TEntity>();
	}

	public virtual async Task Add(TEntity obj)
	{
		try
		{
			await dbSet.AddAsync(obj);
			await _dataContext.SaveChangesAsync();
		}
		catch(Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}

	public List<TEntity> GetByPage(int page)
	{
		const float pageResults = 10f;

		return dbSet
			.Skip((page - 1) * dbSet.Count())
			.Take((int)pageResults)
			.ToList();
	}

	public List<TEntity> GetAll()
	{
		return dbSet.ToList();
	}

	public virtual List<TEntity> GetProducts()
	{
		return dbSet.ToList();
	}

	public TEntity GetById(Guid id)
	{
		return dbSet.Find(id);
	}

	public virtual async Task Remove(TEntity obj)
	{
		dbSet.Remove(obj);
		await _dataContext.SaveChangesAsync();
	}

	public virtual async Task Update(TEntity obj)
	{
		try
		{
			_dataContext.Entry(obj).State = EntityState.Modified;
			await _dataContext.SaveChangesAsync();
		}
		catch(Exception ex)
		{
			throw ex;
		}
	}

	public virtual async Task Patch(JsonPatchDocument obj, Guid id)
	{
		var result = await dbSet.FindAsync(id);
		if(result != null)
			obj.ApplyTo(result);
		await _dataContext.SaveChangesAsync();
	}
}