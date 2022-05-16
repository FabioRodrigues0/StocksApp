using BuyRequest.Domain.Models;
using Infrastructure.Shared.Interfaces;

namespace BuyRequest.Data.Repositories.Interfaces;

public interface IBuyRequestRepository : IRepositoryBase<BuyRequests>
{
	Task<BuyRequests> GetByClientIdAsync(Guid id);
}