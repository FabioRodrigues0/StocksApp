using System;
using System.Threading.Tasks;
using Infrastructure.Shared.Repository.Interface;
using Stock.Domain.Entities;

namespace Stock.Data.Repositories.Interfaces
{
	public interface IProductsMovementRepository : IRepositoryBase<ProductsMovement>
	{
		Task<ProductsMovement> GetByIdWithStorageIdAsync(Guid id, Guid storageId);
	}
}