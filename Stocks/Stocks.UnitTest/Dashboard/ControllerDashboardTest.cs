using MediatR;
using Moq;
using Moq.AutoMock;
using Stock.Api.Controllers;
using Stock.Application.DTO;
using Stock.Application.Queries;
using Xunit;

namespace Stocks.UnitTest.Dashboard
{
	public class ControllerDashboardTest
	{
		public readonly AutoMocker _mocker;
		public ControllerDashboardTest()
		{
			_mocker = new AutoMocker();
		}

		[Fact]
		public async Task ControllerDashboard_GetTopFive()
		{
			//Arrange
			var pageProducts = new ModelFaker().pageProducts;

			var handler = _mocker.GetMock<IRequestHandler<GetTopFive, PagesProductsDto>>();
			var mediator = _mocker.GetMock<IMediator>();

			var requestTest = new GetTopFive { };
			var cancellationToken = new CancellationToken();

			mediator.Setup(x => x.Send(requestTest, cancellationToken)).ReturnsAsync(pageProducts);
			handler.Setup(x => x.Handle(requestTest, cancellationToken)).ReturnsAsync(pageProducts);

			var controller = _mocker.CreateInstance<DashboardController>();

			//Act
			controller.Get();

			//Assert
			handler.Verify(x => x.Handle(requestTest, cancellationToken), Times.Once);
		}

		[Fact]
		public async Task ControllerDashboard_GetAllDashboard()
		{
			//Arrange
			var pageProducts = new ModelFaker().pageProducts;

			var handler = _mocker.GetMock<IRequestHandler<GetAllDashboard, PagesProductsDto>>();
			var mediator = _mocker.GetMock<IMediator>();

			var requestTest = new GetAllDashboard { page = 1 };
			var cancellationToken = new CancellationToken();

			mediator.Setup(x => x.Send(requestTest, cancellationToken)).ReturnsAsync(pageProducts);
			handler.Setup(x => x.Handle(requestTest, cancellationToken)).ReturnsAsync(pageProducts);

			var controller = _mocker.CreateInstance<DashboardController>();

			//Act
			controller.Get(1);

			//Assert
			handler.Verify(x => x.Handle(requestTest, cancellationToken), Times.Once);
		}
	}
}
