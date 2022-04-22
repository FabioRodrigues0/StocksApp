using Microsoft.AspNetCore.JsonPatch;

namespace FinacialApp.Shared;

public interface IRepositoryBase<TEntity> where TEntity : class
{
	Task Add(TEntity obj);

	TEntity GetById(Guid id);

	List<TEntity> GetByPage(int page);

	List<TEntity> GetAll();

	List<TEntity> GetProducts();

	Task Update(TEntity obj);

	Task Remove(TEntity obj);

	Task Patch(JsonPatchDocument obj, Guid id);
}