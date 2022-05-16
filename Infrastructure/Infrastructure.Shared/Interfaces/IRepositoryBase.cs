using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Shared.Interfaces;

public interface IRepositoryBase<T> where T : EntityBase<T>
{
	void SetInclude(Func<IQueryable<T>, IIncludableQueryable<T, object>> include);

	Task<T> Add(T obj);

	Task<T> GetById(Guid id);

	Task<(List<T> list, int totalPages, int page)> GetAll(int page);

	Task<T> Update(T obj);

	Task<bool> Remove(Guid id);

	Task<bool> Remove(T obj);

	Task<T> Patch(T obj);
}