using BuyRequest.Application.DTO;
using BuyRequest.Domain.Models;
using Infrastructure.Shared.Interfaces;

namespace BuyRequest.Application.Services.Interfaces;

public interface IBuyRequestService : IServiceBase<BuyRequests>
{
	Task<(List<BuyRequests> list, int totalPages, int page)> GetAll(int page);

	Task<BuyRequests> GetByClientId(Guid id);
}