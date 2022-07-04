using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

namespace Stock.Data.Repositories
{
	public class MovementsRepository : RepositoryBase<Movements>, IMovementsRepository
	{
		private readonly IConfiguration _config;
		private readonly ILogger<MovementsRepository> _logger;

		public MovementsRepository(
			IConfiguration config,
			ILogger<MovementsRepository> logger,
			MovementsContext context) : base(logger, context)
		{
			_config = config;
			_logger = logger;
			SetInclude(x => x.Include(z => z.ProductsMovements));
		}

		public override async Task<Movements> GetByIdAsync(Guid id)
		{
			_logger.LogInformation("Call a Movements with Id = {id}", id);
			await using var connection = _dataContext.Database.GetDbConnection();
			var sql = @"SELECT * FROM [StocksApp].[query].[QueryMovements] WHERE Id = @id";
			var result = await connection.QueryFirstOrDefaultAsync<Movements>(sql, new { Id = id });
			return result;
		}

		public override async Task<PagesBase<Movements>> GetAllAsync(int page, int itemsPerPage)
		{
			_logger.LogInformation("Call all Movements from page {page}", page);
			await using var connection = _dataContext.Database.GetDbConnection();
			var sql = @$"SELECT
									m.Id
									,m.Origin
									,m.OriginId
									,m.Date
									,m.Type
									,p.Id
									,p.MovementsId
									,p.ProductId
									,p.ProductDescription
									,p.ProductCategory
									,p.Quantity
									,p.ValorPerUnit
									,p.StorageId
									,p.StorageDescription
								FROM query.QueryMovements AS m
								LEFT JOIN query.QueryProductsMovement AS p ON m.Id = p.MovementsId
								ORDER BY m.Id
								OFFSET {itemsPerPage} * ({page} - 1) ROWS
								FETCH NEXT {itemsPerPage} ROWS ONLY;";
			var result = await connection.QueryAsync<Movements, ProductsMovement, Movements>(sql, (movement, productsMovement) =>
			{
				if (movement.ProductsMovements == null)
				{
					movement.ProductsMovements = new List<ProductsMovement>();
					movement.ProductsMovements.Add(productsMovement);
				}
				else
				{
					movement.ProductsMovements.Add(productsMovement);
				}
				return movement;
			},
			splitOn: "Id");
			var totalPages = (int)Math.Ceiling(dbSet.Count() / (float)itemsPerPage);
			return ConvertToPages(result.ToList(), page, totalPages);
		}

		public override PagesBase<Movements> ConvertToPages(List<Movements> list, int page, int totalPages)
		{
			return new PagesBase<Movements>
			{
				Models = list,
				CurrentPage = page,
				Pages = totalPages
			};
		}
	}
}