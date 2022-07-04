#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Infrastructure.Shared.Entities;
using Infrastructure.Shared.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Stock.Data.Repositories.Interfaces;
using Stock.Domain.Entities;

#endregion

namespace Stock.Data.Repositories
{
	public class ProductsMovementRepository : RepositoryBase<ProductsMovement>, IProductsMovementRepository
	{
		private readonly ILogger<ProductsMovementRepository> _logger;

		public ProductsMovementRepository(
			ILogger<ProductsMovementRepository> logger,
			MovementsContext context) : base(logger, context)
		{
			_logger = logger;
		}

		public override async Task<ProductsMovement> GetByIdAsync(Guid id)
		{
			_logger.LogInformation("Call a Product with Id = {id}", id);
			await using var connection = _dataContext.Database.GetDbConnection();
			var sql = @$"SELECT * FROM [StocksApp].[query].[QueryProductsMovement] WHERE Id = @id";
			var result = await connection.QueryFirstOrDefaultAsync<ProductsMovement>(sql, new { Id = id });
			return result;
		}

		public async Task<ProductsMovement> GetByIdWithStorageIdAsync(Guid id, Guid storageId)
		{
			_logger.LogInformation("Call a Product with Id = {id} and {storageId}", id, storageId);
			await using var connection = _dataContext.Database.GetDbConnection();
			var sql = @$"SELECT * FROM [StocksApp].[query].[QueryProductsMovement] WHERE Id = @id AND StorageId = @storageId";

			var result = await connection.QueryFirstOrDefaultAsync<ProductsMovement>(sql, new { Id = id, StorageId = storageId });
			return result;
		}

		public override async Task<PagesBase<ProductsMovement>> GetAllAsync(int page, int itemsPerPage)
		{
			_logger.LogInformation("Call all Movements from page {page}", page);
			await using var connection = _dataContext.Database.GetDbConnection();
			var sql = @$"SELECT p.Id
								,p.MovementsId
								,p.ProductId
								,p.ProductDescription
								,p.ProductCategory
								,p.Quantity
								,p.ValorPerUnit
								,p.StorageId
								,p.StorageId
							FROM query.QueryProductsMovement p
							ORDER BY p.Id
							OFFSET {itemsPerPage * (page - 1)} ROWS
							FETCH NEXT {itemsPerPage} ROWS ONLY";
			var result = await connection.QueryAsync<ProductsMovement>(sql);
			var totalPages = (int)Math.Ceiling(dbSet.Count() / (float)itemsPerPage);
			return ConvertToPages(result.ToList(), page, totalPages);
		}

		public override PagesBase<ProductsMovement> ConvertToPages(List<ProductsMovement> list, int page, int totalPages)
		{
			return new PagesBase<ProductsMovement>
			{
				Models = list,
				CurrentPage = page,
				Pages = totalPages
			};
		}
	}
}