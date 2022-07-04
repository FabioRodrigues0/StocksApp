using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Shared.Entities;
using Infrastructure.Shared.Repository.Interface;
using Stock.Domain.Entities;

namespace Stock.Data.Repositories.Interfaces
{
	public interface IDashBoardRepository : IRepositoryBase<ProductsMovement>
	{
		Task<PagesBase<ProductsMovement>> GetAll(int page, int itemsPerPage);

		Task<PagesBase<ProductsMovement>> GetBestSellers();
	}
}