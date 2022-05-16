using BuyRequest.Service.Interface;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Models;
using FinancialApp.Shared;
using FinancialApp.Shared.Enums;
using FinancialApp.Shared.Interfaces;

namespace BuyRequest.Service;

public class BuyRequestService : ServiceBase<BuyRequest>, IBuyRequestService
{
	private readonly IBuyRequestRepository _buyRequestRepository;
	private readonly IBuyRequestProductService _buyRequestProductService;

	public BuyRequestService(
		IServiceContext serviceContext,
		IBuyRequestRepository buyRequestRepository,
		IBuyRequestProductService buyRequestProductService)
		: base(buyRequestRepository, serviceContext)
	{
		_buyRequestRepository = buyRequestRepository;
		_buyRequestProductService = buyRequestProductService;
	}

	public override async Task<BuyRequest> Add(BuyRequest model)
	{
		ValidateEntity(model);
		//AddNotification("Erro de negocio");
		if (!IsValidOperation)
			return null;

		return await _buyRequestRepository.Add(model);
	}

	public override async Task<BuyRequest> Update(BuyRequest model)
	{
		ValidateEntity(model);
		var result = await _buyRequestRepository.GetById(model.Id);
		if (result.Status == Status.Finished && model.Status != Status.Finished)
			AddNotification("Request mark as Finished can't be modified");
		if (!IsValidOperation)
			return null;
		return await _buyRequestRepository.Update(model);
	}

	public override async Task<BuyRequest> Patch(BuyRequest model)
	{
		ValidateEntity(model);
		var result = await _buyRequestRepository.GetById(model.Id);
		if (result.Status == Status.Finished && model.Status != Status.Finished)
			AddNotification("Request mark as Finished can't be modified");
		if (!IsValidOperation)
			return null;

		return await _buyRequestRepository.Patch(model);
	}
}