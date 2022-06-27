using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Infrastructure.Shared.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Stock.Data.Repositories.Interfaces;
using Stock.Domain.Models;

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

		public override async Task<Movements> AddAsync(Movements obj)
		{
			_logger.LogInformation("Create new Stock");
			await dbSet.AddAsync(obj);
			await _dataContext.SaveChangesAsync();
			//await using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			//var sql = @"INSERT INTO Movements (Id, Origin, OriginId, Date, Type)
			//				 VALUES
			//				 (@Id, @Origin, @OriginId, @Date, @Type)";
			//await connection.ExecuteAsync(sql, obj);
			//var sql2 = @$"INSERT INTO ProductsMovement ([Id], [MovementsId], [ProductId] ,[ProductDescription] ,[ProductCategory] ,[Quantity] ,[ValorPerUnit] ,[StorageId] ,[StorageDescription])
			//				 VALUES
			//				 (@Id, @MovementsId, @ProductId, @ProductDescription, @ProductCategory, @Quantity, @ValorPerUnit, @StorageId, @StorageDescription)";
			//var products = obj.ProductsMovements;
			//foreach (var p in products)
			//{
			//	p.MovementsId = obj.Id;
			//	await connection.ExecuteAsync(sql2, p);
			//}
			return obj;
		}

		public override async Task<bool> RemoveAsync(Guid id)
		{
			_logger.LogInformation("Call to Delete a Movements with Id = {id}", id);
			await using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			var sql = @"DELETE * FROM [StocksApp].[dbo].[Movements] WHERE Id = @id";
			var result = await connection.ExecuteAsync(sql, new { Id = id });
			if (result != 0)
				return true;
			return false;
		}

		public override async Task<Movements> GetByIdAsync(Guid id)
		{
			_logger.LogInformation("Call a Movements with Id = {id}", id);
			await using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			var sql = @"SELECT * FROM [StocksApp].[query].[QueryMovements] WHERE Id = @id";
			var result = await connection.QueryFirstAsync<Movements>(sql, new { Id = id });
			return result;
		}

		public override async Task<(List<Movements> list, int totalPages, int page)> GetAllAsync(int page)
		{
			_logger.LogInformation("Call all Movements from page {page}", page);
			await using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			var sql = @"SELECT * FROM [StocksApp].[query].[QueryMovements]";
			var result = await connection.QueryAsync<Movements>(sql);
			return (result.ToList(), 1, page);
		}
	}
}