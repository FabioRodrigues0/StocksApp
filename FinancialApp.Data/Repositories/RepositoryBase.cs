using FinacialApp.Data;
using FinacialApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace FinancialApp.Data;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
	private readonly DataContext _dataContext;

	public RepositoryBase(DataContext dataContext)
	{
		_dataContext = dataContext;
	}

	public void Add(TEntity obj)
	{
		try
		{
			_dataContext.Set<TEntity>().Add(obj);
			_dataContext.SaveChanges();
		}
		catch(Exception ex)
		{
			throw ex;
		}
	}

	public IEnumerable<TEntity> GetAll()
	{
		return _dataContext.Set<TEntity>().ToList();
	}

	public TEntity GetById(int id)
	{
		return _dataContext.Set<TEntity>().Find(id);
	}

	public void Remove(TEntity obj)
	{
		try
		{
			_dataContext.Set<TEntity>().Remove(obj);
			_dataContext.SaveChanges();
		}
		catch(Exception ex)
		{
			throw ex;
		}
	}

	public void Dispose()
	{
		throw new NotImplementedException();
	}

	public void Update(TEntity obj)
	{
		try
		{
			_dataContext.Entry(obj).State = EntityState.Modified;
			_dataContext.SaveChanges();
		}
		catch(Exception ex)
		{
			throw ex;
		}
	}
}