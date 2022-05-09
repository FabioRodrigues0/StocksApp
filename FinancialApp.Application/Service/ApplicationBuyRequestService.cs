using AutoMapper;
using FinancialApp.Application.Interface;
using FinancialApp.Domain.Core.Services;
using FinancialApp.Domain.Models;
using FinancialApp.DTO.DTO;

namespace FinancialApp.Application.Service;

public class ApplicationBuyRequestService : IApplicationBuyRequestService
{
	private readonly IBuyRequestService _buyRequestService;
	private readonly IMapper _mapper;

	public ApplicationBuyRequestService(
		IBuyRequestService buyRequestService,
		IMapper mapper)
	{
		_buyRequestService = buyRequestService;
		_mapper = mapper;
	}

	public async Task<BuyRequest> Add(BuyRequestDto obj)
	{
		var result = _mapper.Map<BuyRequest>(obj);
		return await _buyRequestService.Add(result);
	}

	public async Task<BuyRequestDto> GetById(Guid id)
	{
		var buyRequests = await _buyRequestService.GetById(id);
		return _mapper.Map<BuyRequestDto>(buyRequests);
	}

	public async Task<PagesBuyRequestDto> GetAll(int page)
	{
		var pages = new PagesBuyRequestDto();
		const int pageResults = 10;

		var buyRequests = await _buyRequestService.GetAll();
		var result = buyRequests.Skip((page - 1) * pageResults).Take(pageResults).ToList();

		var toPages = _mapper.Map<List<BuyRequestDto>>(result);
		pages = _mapper.Map<PagesBuyRequestDto>(toPages);

		pages.CurrentPage = page;
		pages.Pages = (int)Math.Ceiling(buyRequests.Count() / 10f);

		return pages;
	}

	public async Task<BuyRequest> Update(BuyRequestUpdateDto obj)
	{
		var result = _mapper.Map<BuyRequest>(obj);
		return await _buyRequestService.Update(result);
	}

	public async Task<BuyRequest> Patch(BuyRequestPatchDto obj)
	{
		var result = _mapper.Map<BuyRequest>(obj);
		return await _buyRequestService.Patch(result);
	}

	public async Task<BuyRequest> Remove(Guid id)
	{
		return await _buyRequestService.Remove(id);
	}
}