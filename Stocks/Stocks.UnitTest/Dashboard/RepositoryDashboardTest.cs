using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.AutoMock;
using Shouldly;
using Stock.Data;
using Stock.Data.Repositories;
using Stock.Data.Repositories.Interfaces;
using Xunit;

namespace Stocks.UnitTest.Dashboard
{
	public class RepositoryDashboardTest
	{
		public readonly AutoMocker _mocker;
		public RepositoryDashboardTest()
		{
			_mocker = new AutoMocker();
		}
		[Fact]
		public async Task DashBoardRepository_GetAll_Test()
		{
			#region Arrange
			var commandFaker = new ModelFaker();
			int totalPages = 1, page = 1;
			var products = (commandFaker.listProductsModel, totalPages, page);

			//
			var config = _mocker.GetMock<IDashBoardRepository>();
			config.Setup(x => x.GetAll(1)).ReturnsAsync(products);

			var c = _mocker.GetMock<IConfiguration>();
			var l = _mocker.GetMock<ILogger<DashBoardRepository>>();

			//Mock Instances
			var repository = _mocker.CreateInstance<DashBoardRepository>(true);

			#endregion Arrange

			#region Act

			var taskResult = Task.Run(async () =>  {await repository.GetAll(1); });

			#endregion Act

			#region Assert

			await taskResult.ShouldNotThrowAsync();

			#endregion Assert
		}

		[Fact]
		public async Task DashBoardRepository_GetBestSellers_Test()
		{
			#region Arrange
			var movements = new ModelFaker().movements;

			//Mock Instances
			var repository = _mocker.CreateInstance<DashBoardRepository>();

			#endregion Arrange

			#region Act

			var taskResult = Task.Run(async () => {await repository.GetBestSellers(); });

			#endregion Act

			#region Assert

			await taskResult.ShouldNotThrowAsync();

			#endregion Assert
		}
	}
}
