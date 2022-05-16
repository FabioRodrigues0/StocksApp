namespace Infrastructure.Shared.Interfaces;

public interface IServiceBase<T> where T : EntityBase<T>
{
	Task<T> Add(T obj);

	Task<T> Update(T obj);

	Task<bool> Remove(Guid id);

	Task<T> Patch(T obj);

	Task<(List<T> list, int totalPages, int page)> GetAll(int page);

	Task<T> GetById(Guid id);

	bool ValidateEntity(T domain);

	void NoContent(bool content);

	void AddNotification(string message);
}