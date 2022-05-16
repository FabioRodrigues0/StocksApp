using BuyRequest.Application.DTO;
using BuyRequest.Domain.Models;

namespace BuyRequest.Application.Application.Interface;

public interface IApplicationBuyRequestService
{
	Task<BuyRequests> Add(BuyRequestDto obj);

	Task<BuyRequestDto> GetById(Guid id);

	Task<BuyRequestDto> GetByClientId(Guid id);

	Task<PagesBuyRequestDto> GetAll(int page);

	Task<BuyRequests> Update(BuyRequestUpdateDto obj);

	Task<BuyRequests> Patch(BuyRequestPatchDto obj);

	Task<bool> Remove(Guid id);
}