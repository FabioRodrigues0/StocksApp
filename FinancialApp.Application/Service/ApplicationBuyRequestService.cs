using AutoMapper;
using FinancialApp.Application.Interface;
using FinancialApp.CrossCutting.Adapter.Interfaces;
using FinancialApp.Domain.Core.Services;
using FinancialApp.DTO.DTO;
using Microsoft.AspNetCore.JsonPatch;

namespace FinancialApp.Application.Service;

public class ApplicationBuyRequestService : IApplicationBuyRequestService
{
	private readonly IBuyRequestService _buyRequestService;
	private readonly IBuyRequestProductService _buyRequestProductService;
	private readonly IBuyRequestMapper _buyRequestMapper;

	public ApplicationBuyRequestService(IBuyRequestService buyRequestService,
																			IBuyRequestMapper buyRequestMapper,
																			IBuyRequestProductService buyRequestProductService)
	{
		_buyRequestService = buyRequestService;
		_buyRequestProductService = buyRequestProductService;
		_buyRequestMapper = buyRequestMapper;
	}

	public async Task Add(BuyRequestDto obj)
	{
		var buyRequests = _buyRequestMapper.MapperToEntity(obj);
		await _buyRequestService.Add(buyRequests);
	}

	public BuyRequestDto GetById(Guid id)
	{
		var buyRequests = _buyRequestService.GetById(id);
		var buyRequestsProducts = _buyRequestProductService.GetProducts();
		if(buyRequestsProducts.Count == 1)
		{
			buyRequests.Products.AddRange(buyRequestsProducts);
		}
		else
		{
			foreach(var result in buyRequestsProducts.Select(br => buyRequestsProducts.ToList().Where(p => p.Id == id)))
			{
				buyRequests.Products.AddRange(result);
			}
		}

		var buyRequestDto = _buyRequestMapper.MapperToDTO(buyRequests);

		return buyRequestDto;
	}

	public PagesBuyRequestDto GetByPage(int page)
	{
		var buyRequests = _buyRequestService.GetByPage(page);
		var buyRequestsProducts = _buyRequestProductService.GetProducts();
		foreach(var br in buyRequests)
		{
			var result = buyRequestsProducts.ToList().Where(p => p.Id == br.Id);
			br.Products.AddRange(result);
		}

		var buyRequestDto = _buyRequestMapper.MapperListBuyRequest(buyRequests, page);

		return buyRequestDto;
	}

	public PagesBuyRequestDto GetAll()
	{
		var buyRequests = _buyRequestService.GetAll();
		var buyRequestsProducts = _buyRequestProductService.GetProducts();
		foreach(var br in buyRequests)
		{
			var result = buyRequestsProducts.ToList().Where(p => p.Id == br.Id);
			br.Products.AddRange(result);
			br.Products.Count();
		}

		var buyRequestDto = _buyRequestMapper.MapperListBuyRequest(buyRequests, 1);

		return buyRequestDto;
	}

	public void Update(BuyRequestDto obj)
	{
		var buyRequests = _buyRequestMapper.MapperToEntity(obj);
		_buyRequestService.Update(buyRequests);
	}

	public Task Patch(JsonPatchDocument obj, Guid id)
	{
		return _buyRequestService.Patch(obj, id);
	}

	public void Remove(BuyRequestDto obj)
	{
		var buyRequests = _buyRequestMapper.MapperToEntity(obj);
		_buyRequestService.Remove(buyRequests);
	}
}