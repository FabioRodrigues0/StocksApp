using FinancialApp.DTO.DTO;
using Microsoft.AspNetCore.JsonPatch;

namespace FinancialApp.Application.Interface;

public interface IApplicationBuyRequestService
{
	Task Add(BuyRequestDto obj);

	BuyRequestDto GetById(Guid id);

	PagesBuyRequestDto GetByPage(int page);

	PagesBuyRequestDto GetAll();

	void Update(BuyRequestDto obj);

	Task Patch(JsonPatchDocument obj, Guid id);

	void Remove(BuyRequestDto obj);
}