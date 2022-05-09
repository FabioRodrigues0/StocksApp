using AutoMapper;
using FinancialApp.Application.Interface;
using FinancialApp.Domain.Core.Services;
using FinancialApp.Domain.Models;
using FinancialApp.DTO.DTO;

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
		return await _cashBookService.Add(result);
	}

	public async Task<CashBookDto> GetById(Guid id)
	{
		var cashBooks = await _cashBookService.GetById(id);
		return _mapper.Map<CashBookDto>(cashBooks);
	}

	public async Task<List<CashBookDto>> GetByOriginId(Guid id)
	{
		var cashBooks = await _cashBookService.GetByOriginId(id);
		return _mapper.Map<List<CashBookDto>>(cashBooks);
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
		return await _cashBookService.Update(result);
	}
}