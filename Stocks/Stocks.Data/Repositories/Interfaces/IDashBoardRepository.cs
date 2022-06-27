using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Shared.Repository.Interface;
using Stock.Domain.Models;

namespace Stock.Data.Repositories.Interfaces
{
	public interface IDashBoardRepository : IRepositoryBase<ProductsMovement>
	{
		Task<(List<ProductsMovement> list, int totalPages, int page)> GetAll(int page);

		Task<(List<ProductsMovement> list, int totalPages, int page)> GetBestSellers();
	}
}