using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Infrastructure.Shared.Entities;
using Infrastructure.Shared.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stock.Data.Repositories.Interfaces;
using Stock.Domain.Entities;

namespace Stock.Data.Repositories
{
	public class DashBoardRepository : RepositoryBase<ProductsMovement>, IDashBoardRepository
	{
		private readonly ILogger<DashBoardRepository> _logger;

		public DashBoardRepository(
			ILogger<DashBoardRepository> logger,
			MovementsContext context) : base(logger, context)
		{
			_logger = logger;
		}

		public async Task<PagesBase<ProductsMovement>> GetAll(int page, int itemsPerPage)
		{
			_logger.LogInformation("Calls all Products in database");
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

		public async Task<PagesBase<ProductsMovement>> GetBestSellers()
		{
			_logger.LogInformation("Calls Top 5 most selled Products");
			await using var connection = _dataContext.Database.GetDbConnection();
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
			var totalPages = (int)Math.Ceiling(dbSet.Count() / (float)5);
			return ConvertToPages(result.ToList(), 1, totalPages);
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