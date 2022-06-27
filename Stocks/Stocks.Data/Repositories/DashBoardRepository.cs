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

namespace Stock.Data.Repositories
{
	public class DashBoardRepository : RepositoryBase<ProductsMovement>, IDashBoardRepository
	{
		private readonly IConfiguration _config;
		private readonly ILogger<DashBoardRepository> _logger;

		public DashBoardRepository(
			IConfiguration config,
			ILogger<DashBoardRepository> logger,
			MovementsContext context) : base(logger, context)
		{
			_config = config;
			_logger = logger;
		}

		public async Task<(List<ProductsMovement> list, int totalPages, int page)> GetAll(int page)
		{
			_logger.LogInformation("Calls all Products in database");
			await using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			var sql = @$"SELECT * FROM [StocksApp].[query].[QueryProductsMovement]";

			var result = await connection.QueryAsync<ProductsMovement>(sql);
			return (result.ToList(), 1, 1);
		}

		public async Task<(List<ProductsMovement> list, int totalPages, int page)> GetBestSellers()
		{
			_logger.LogInformation("Calls Top 5 most selled Products");
			await using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			var sql = @$"SELECT TOP(5)
								p.Id
								,p.MovementsId
								,p.ProductId
								,p.ProductDescription
								,p.ProductCategory
								,p.Quantity
								,p.ValorPerUnit
								,p.StorageId
								,p.StorageId
							FROM
								query.QueryProductsMovement p
							OUTER APPLY(SELECT
									m.Type,
									m.Id
								FROM
									query.QueryMovements m) Movement
							WHERE Movement.Type = 2 AND p.MovementsId = Movement.Id
							ORDER BY p.Quantity DESC";

			var result = await connection.QueryAsync<ProductsMovement>(sql);
			return (result.ToList(), 1, 1);
		}
	}
}