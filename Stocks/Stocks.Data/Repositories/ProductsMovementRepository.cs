#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Infrastructure.Shared.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Stock.Data.Repositories.Interfaces;
using Stock.Domain.Models;

#endregion

namespace Stock.Data.Repositories
{
	public class ProductsMovementRepository : RepositoryBase<ProductsMovement>, IProductsMovementRepository
	{
		private readonly IConfiguration _config;
		private readonly ILogger<ProductsMovementRepository> _logger;

		public ProductsMovementRepository(
			IConfiguration config,
			ILogger<ProductsMovementRepository> logger,
			MovementsContext context) : base(logger, context)
		{
			_config = config;
			_logger = logger;
		}

		public override async Task<ProductsMovement> GetByIdAsync(Guid id)
		{
			_logger.LogInformation("Call a Product with Id = {id}", id);
			await using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			var sql = @$"SELECT * FROM [StocksApp].[query].[QueryProductsMovement] WHERE Id = @id";
			var result = await connection.QueryFirstAsync<ProductsMovement>(sql, new { Id = id });
			return result;
		}

		public async Task<ProductsMovement> GetByIdWithStorageIdAsync(Guid id, Guid storageId)
		{
			_logger.LogInformation("Call a Product with Id = {id} and {storageId}", id, storageId);
			await using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			var sql = @$"SELECT * FROM [StocksApp].[query].[QueryProductsMovement] WHERE Id = @id AND StorageId = @storageId";

			var result = await connection.QueryFirstAsync<ProductsMovement>(sql, new { Id = id, StorageId = storageId });
			return result;
		}

		public override async Task<(List<ProductsMovement> list, int totalPages, int page)> GetAllAsync(int page)
		{
			_logger.LogInformation("Call all Movements from page {page}", page);
			await using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			var sql = @$"SELECT * FROM [StocksApp].[query].[QueryProductsMovement]";
			var result = await connection.QueryAsync<ProductsMovement>(sql);
			return (result.ToList(), 1, page);
		}
	}
}