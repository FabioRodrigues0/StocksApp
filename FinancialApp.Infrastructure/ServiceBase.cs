using FinacialApp.Shared;
using FinancialApp.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace FinancialApp.Shared;

public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
{
	private readonly IRepositoryBase<TEntity> _TEntityRepository;

	public ServiceBase(IRepositoryBase<TEntity> tEntityRepository)
	{
		_TEntityRepository = tEntityRepository;
	}

	public virtual async Task Add(TEntity obj)
	{
		await _TEntityRepository.Add(obj);
	}

	public List<TEntity> GetProducts()
	{
		return _TEntityRepository.GetProducts();
	}

	public virtual TEntity GetById(Guid id)
	{
		return _TEntityRepository.GetById(id);
	}

	public List<TEntity> GetByPage(int page)
	{
		return _TEntityRepository.GetByPage(page);
	}

	public virtual List<TEntity> GetAll()
	{
		return _TEntityRepository.GetAll();
	}

	public virtual void Update(TEntity obj)
	{
		_TEntityRepository.Update(obj);
	}

	public virtual Task Patch(JsonPatchDocument obj, Guid id)
	{
		return _TEntityRepository.Patch(obj, id);
	}

	public virtual void Remove(TEntity obj)
	{
		_TEntityRepository.Remove(obj);
	}
}