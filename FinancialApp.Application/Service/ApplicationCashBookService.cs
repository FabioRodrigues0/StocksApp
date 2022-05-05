using AutoMapper;
using FinancialApp.Application.Interface;
using FinancialApp.Domain.Core.Services;
using FinancialApp.Domain.Models;
using FinancialApp.DTO.DTO;
using Microsoft.AspNetCore.JsonPatch;

namespace FinancialApp.Application.Service;

public class ApplicationCashBookService : IApplicationCashBookService
{
	private readonly ICashBookService _cashBookService;
	private readonly IMapper _mapper;

	public ApplicationCashBookService(ICashBookService cashBookService, IMapper mapper)

	{
		_cashBookService = cashBookService;
		_mapper = mapper;
	}

	public async Task<CashBook> Add(CashBookDto obj)
	{
		var result = _mapper.Map<CashBook>(obj);
		var response = await _cashBookService.Add(result);
		return response;
	}

	public async Task<CashBookDto> GetById(Guid id)
	{
		var cashBooks = await _cashBookService.GetById(id);
		var cashBookDto = _mapper.Map<CashBookDto>(cashBooks);

		return cashBookDto;
	}

	public async Task<List<CashBookDto>> GetByOriginId(Guid id)
	{
		var cashBooks = await _cashBookService.GetByOriginId(id);
		var cashBookDto = _mapper.Map<List<CashBookDto>>(cashBooks);

		return cashBookDto;
	}

	public async Task<PagesCashBookDto> GetAll(int page)
	{
		var pages = new PagesCashBookDto();
		const int pageResults = 10;

		var cashBooks = await _cashBookService.GetAll();
		var result = cashBooks.Skip((page - 1) * pageResults).Take(pageResults).ToList();

		var toPages = _mapper.Map<List<CashBookDto>>(result);
		pages = _mapper.Map<PagesCashBookDto>(toPages);

		pages.CurrentPage = page;
		pages.Pages = (int)Math.Ceiling(cashBooks.Count() / 10f);

		return pages;
	}

	public async Task<CashBook> Update(CashBookUpdateDto obj)
	{
		var result = _mapper.Map<CashBook>(obj);
		var response = await _cashBookService.Update(result);
		return response;
	}
}