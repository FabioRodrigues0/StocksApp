using FinancialApp.Domain.Models;
using FinancialApp.DTO.DTO;

namespace FinancialApp.Application.Interface;

public interface IApplicationBuyRequestService
{
	Task<BuyRequest> Add(BuyRequestDto obj);

	Task<BuyRequestDto> GetById(Guid id);

	Task<PagesBuyRequestDto> GetAll(int page);

	Task<BuyRequest> Update(BuyRequestUpdateDto obj);

	Task<BuyRequest> Patch(BuyRequestPatchDto obj);

	Task<BuyRequest> Remove(Guid id);
}