using Microsoft.AspNetCore.JsonPatch;

namespace FinancialApp.Shared;

public interface IServiceBase<TEntity> where TEntity : class
{
	Task Add(TEntity obj);

	void Update(TEntity obj);

	void Remove(TEntity obj);

	List<TEntity> GetByPage(int page);

	List<TEntity> GetAll();

	List<TEntity> GetProducts();

	TEntity GetById(Guid id);

	Task Patch(JsonPatchDocument obj, Guid id);
}