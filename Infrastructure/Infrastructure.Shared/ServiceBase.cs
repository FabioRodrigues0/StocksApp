using FluentValidation.Results;
using Infrastructure.Shared.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Shared;

public abstract class ServiceBase<T> : IServiceBase<T> where T : EntityBase<T>
{
	private readonly IRepositoryBase<T> _tEntityRepository;
	protected readonly IServiceContext _serviceContext;
	private readonly ILogger<ServiceBase<T>> _logger;

	protected ServiceBase(
		ILogger<ServiceBase<T>> logger,
		IRepositoryBase<T> tEntityRepository,
		IServiceContext serviceContext)
	{
		_logger = logger;
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

	public virtual async Task<(List<T> list, int totalPages, int page)> GetAll(int page)
	{
		return await _tEntityRepository.GetAll(page);
	}

	public virtual async Task<T> Update(T obj)
	{
		return await _tEntityRepository.Update(obj);
	}

	public virtual Task<T> Patch(T obj)
	{
		return _tEntityRepository.Patch(obj);
	}

	public virtual async Task<bool> Remove(Guid id)
	{
		return await _tEntityRepository.Remove(id); ;
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
		_logger.LogError(error.ToString());
		AddNotification(error.ErrorMessage);
	}

	public void NoContent(bool content) => _serviceContext.NoContent(content);

	public void AddNotification(string message) => _serviceContext.AddNotification(message);

	public bool IsValidOperation => !_serviceContext.HasNotification();
}