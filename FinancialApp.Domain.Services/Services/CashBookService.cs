using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Core.Services;
using FinancialApp.Domain.Models;
using FinancialApp.Shared;
using FinancialApp.Shared.Interfaces;

namespace FinancialApp.Domain.Services.Services;

public class CashBookService : ServiceBase<CashBook>, ICashBookService
{
	private readonly ICashBookRepository _cashBookRepository;

	public CashBookService(
			IServiceContext serviceContext,
			ICashBookRepository cashBookRepository)
			: base(cashBookRepository, serviceContext)
	{
		_cashBookRepository = cashBookRepository;
	}

	public async Task<List<CashBook>> GetByOriginId(Guid id)
	{
		return await _cashBookRepository.GetByOriginId(id);
	}

	public override async Task<CashBook> Add(CashBook model)
	{
		ValidateEntity(model);
		//AddNotification("Erro de negocio");
		if(!IsValidOperation)
			return null;

		return await _cashBookRepository.Add(model);
	}

	public override async Task<CashBook> Update(CashBook model)
	{
		ValidateEntity(model);
		var result = await _cashBookRepository.GetById(model.Id);
		if(result.IsEdited)
			AddNotification("Cash book inserted integration can't be modified");
		if(!IsValidOperation)
			return null;
		return await _cashBookRepository.Update(model);
	}
}