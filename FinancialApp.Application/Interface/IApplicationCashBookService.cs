using FinancialApp.DTO.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.Application.Interface;

public interface IApplicationCashBookService
{
	Task Add(CashBookDto obj);

	CashBookDto GetById(Guid id);

	PagesCashBookDto GetByPage(int page);

	PagesCashBookDto GetAll();

	void Update(CashBookDto obj);

	Task Patch(JsonPatchDocument obj, Guid id);

	void Remove(CashBookDto obj);
}