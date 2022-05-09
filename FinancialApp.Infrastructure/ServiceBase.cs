using FinancialApp.Shared.Interfaces;
using FluentValidation.Results;

namespace FinancialApp.Shared;

public abstract class ServiceBase<T> : IServiceBase<T> where T : EntityBase<T>
{
	private readonly IRepositoryBase<T> _tEntityRepository;
	protected readonly IServiceContext _serviceContext;

	protected ServiceBase(
		IRepositoryBase<T> tEntityRepository,
		IServiceContext serviceContext)
	{
		_serviceContext = serviceContext;
		_tEntityRepository = tEntityRepository;
	}

	public virtual async Task<T> Add(T obj)
	{
		return await _tEntityRepository.Add(obj);
	}

	public virtual async Task<T> GetById(Guid id)
	{
		return await _tEntityRepository.GetById(id);
	}

	public virtual async Task<List<T>> GetAll()
	{
		return await _tEntityRepository.GetAll();
	}

	public virtual async Task<T> Update(T obj)
	{
		return await _tEntityRepository.Update(obj);
	}

	public virtual Task<T> Patch(T obj)
	{
		return _tEntityRepository.Patch(obj);
	}

	public virtual async Task<T> Remove(Guid id)
	{
		return await _tEntityRepository.Remove(id);
	}

	public bool ValidateEntity(T domain)
	{
		domain.IsValid();
		if (domain?.ValidationResult?.Errors.Any() == true)
		{
			foreach (var domainErro in domain.ValidationResult.Errors)
				AddNotification(domainErro);
		}

		return IsValidOperation;
	}

	private void AddNotification(ValidationFailure error)
	{
		AddNotification(error.ErrorMessage);
	}

	public void AddNotification(string message) => _serviceContext.AddNotification(message);

	public bool IsValidOperation => !_serviceContext.HasNotification();
}