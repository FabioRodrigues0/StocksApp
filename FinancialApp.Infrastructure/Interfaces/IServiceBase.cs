namespace FinancialApp.Shared.Interfaces;

public interface IServiceBase<T> where T : EntityBase<T>
{
	Task<T> Add(T obj);

	Task<T> Update(T obj);

	Task<T> Remove(Guid id);

	Task<T> Patch(T obj);

	Task<List<T>> GetAll();

	Task<T> GetById(Guid id);

	bool ValidateEntity(T domain);

	void AddNotification(string message);
}