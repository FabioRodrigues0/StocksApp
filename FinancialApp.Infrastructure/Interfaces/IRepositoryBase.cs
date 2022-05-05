using Microsoft.EntityFrameworkCore.Query;

namespace FinancialApp.Shared.Interfaces;

public interface IRepositoryBase<T> where T : EntityBase<T>
{
    void SetInclude(Func<IQueryable<T>, IIncludableQueryable<T, object>> include);

    Task<T> Add(T obj);

    Task<T> GetById(Guid id);

    Task<List<T>> GetAll();

    Task<T> Update(T obj);

    Task<T> Remove(Guid id);

    Task<T> Patch(T obj);
}