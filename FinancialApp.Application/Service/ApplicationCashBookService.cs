using AutoMapper;
using FinacialApp.Domain.Models;
using FinancialApp.Application.Interface;
using FinancialApp.CrossCutting.Adapter.Interfaces;
using FinancialApp.Domain.Core.Services;
using FinancialApp.DTO.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.Application.Service;

public class ApplicationCashBookService : IApplicationCashBookService
{
	private readonly ICashBookService _cashBookService;
	private readonly ICashBookMapper _cashBookMapper;

	public ApplicationCashBookService(ICashBookService cashBookService, ICashBookMapper cashBookMapper)

	{
		_cashBookService = cashBookService;
		_cashBookMapper = cashBookMapper;
	}

	public async Task Add(CashBookDto obj)
	{
		var cashBook = _cashBookMapper.MapperToEntity(obj);
		await _cashBookService.Add(cashBook);
	}

	public CashBookDto GetById(Guid id)
	{
		var cashBooks = _cashBookService.GetById(id);
		var cashBookDto = _cashBookMapper.MapperToDTO(cashBooks);

		return cashBookDto;
	}

	public PagesCashBookDto GetByPage(int page)
	{
		var cashBooks = _cashBookService.GetByPage(page);
		var cashBookDto = _cashBookMapper.MapperListCashBook(cashBooks, page);

		return cashBookDto;
	}

	public PagesCashBookDto GetAll()
	{
		var cashBooks = _cashBookService.GetAll();
		var cashBookDto = _cashBookMapper.MapperListCashBook(cashBooks, 1);

		return cashBookDto;
	}

	public void Update(CashBookDto obj)
	{
		var cashBook = _cashBookMapper.MapperToEntity(obj);
		_cashBookService.Update(cashBook);
	}

	public Task Patch(JsonPatchDocument obj, Guid id)
	{
		return _cashBookService.Patch(obj, id);
	}

	public void Remove(CashBookDto obj)
	{
		var cashBook = _cashBookMapper.MapperToEntity(obj);
		_cashBookService.Remove(cashBook);
	}
}