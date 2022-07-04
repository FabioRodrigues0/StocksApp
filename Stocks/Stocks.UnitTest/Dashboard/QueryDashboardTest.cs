using AutoMapper;
using Infrastructure.Shared.Entities;
using Moq;
using Moq.AutoMock;
using Stock.Application.Application.Handlers.Dashboard;
using Stock.Application.Map;
using Stock.Application.Queries;
using Stock.Data.Repositories.Interfaces;
using Stock.Domain.Entities;
using Xunit;

namespace Stocks.UnitTest.Dashboard
{
	public class QueryDashboardTest
	{
		public readonly AutoMocker _mocker;
		private static IMapper _mapper;

		public QueryDashboardTest()
		{
			_mocker = new AutoMocker();
			if (_mapper == null)
			{
				var mapConfig = new MapperConfiguration(x =>
				{
					x.AddProfile(new MovementAutomapper());
					x.AddProfile(new ProductsMovementAutomapper());
					x.AddProfile(new PagesMapper());
				});
				_mapper = mapConfig.CreateMapper();
			}
		}

		[Fact]
		public async Task Query_GetAllDashboard()
		{
			//Arrange
			var commandFaker = new ModelFaker();
			var products = new PagesBase<ProductsMovement>();

			var repository = _mocker.GetMock<IProductsMovementRepository>();

			repository.Setup(x => x.GetAllAsync(1, 10)).ReturnsAsync(products);

			var handler = _mocker.CreateInstance<GetAllDashboardHandler>();
			var requestTest = new GetAllDashboard { page = 1, itemsPerPage = 10 };
			var cancellationToken = new CancellationToken();

			//Act
			await handler.Handle(requestTest, cancellationToken);

			//Assert
			repository.Verify(x => x.GetAllAsync(1, 10), Times.Once);
		}

		[Fact]
		public async Task Query_GetTopFive()
		{
			//Arrange
			var commandFaker = new ModelFaker();
			var products = new PagesBase<ProductsMovement>();

			var repository = _mocker.GetMock<IDashBoardRepository>();

			repository.Setup(x => x.GetBestSellers()).ReturnsAsync(products);

			var handler = _mocker.CreateInstance<GetTopFiveHandler>();
			var requestTest = new GetTopFive { };
			var cancellationToken = new CancellationToken();

			//Act
			await handler.Handle(requestTest, cancellationToken);

			//Assert
			repository.Verify(x => x.GetBestSellers(), Times.Once);
		}

		[Fact]
		public async Task Query_GetAllDashboard_NoContent()
		{
			//Arrange
			var list = new List<ProductsMovement>();
			var products = new PagesBase<ProductsMovement>();

			var repository = _mocker.GetMock<IProductsMovementRepository>();

			repository.Setup(x => x.GetAllAsync(1, 10)).ReturnsAsync(products);

			var handler = _mocker.CreateInstance<GetAllDashboardHandler>();
			var requestTest = new GetAllDashboard { page = 1, itemsPerPage = 10 };
			var cancellationToken = new CancellationToken();

			//Act
			await handler.Handle(requestTest, cancellationToken);

			//Assert
			repository.Verify(x => x.GetAllAsync(1, 10), Times.Once);
		}

		[Fact]
		public async Task Query_GetTopFive_NoContent()
		{
			//Arrange
			var list = new List<ProductsMovement>();
			var products = new PagesBase<ProductsMovement>();

			var repository = _mocker.GetMock<IDashBoardRepository>();

			repository.Setup(x => x.GetBestSellers()).ReturnsAsync(products);

			var handler = _mocker.CreateInstance<GetTopFiveHandler>();
			var requestTest = new GetTopFive { };
			var cancellationToken = new CancellationToken();

			//Act
			await handler.Handle(requestTest, cancellationToken);

			//Assert
			repository.Verify(x => x.GetBestSellers(), Times.Once);
		}
	}
}