using AutoMapper;
using MediatR;
using Moq;
using Moq.AutoMock;
using Stock.Api.Controllers;
using Stock.Application.Map;
using Stock.Application.Models;
using Stock.Application.Queries;
using Xunit;

namespace Stocks.UnitTest.Products
{
	public class ControllerProductsTest
	{
		public readonly AutoMocker _mocker;
		private static IMapper _mapper;
		public ControllerProductsTest()
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
		public async Task ControllerProducts_GetById()
		{
			//Arrange
			var pageProducts = new ModelFaker().pageProducts;
			var products = new ModelFaker().products;
			var result = _mapper.Map<ProductsMovementModel>(products);

			var handler = _mocker.GetMock<IRequestHandler<GetProductById, ProductsMovementModel>>();
			var mediator = _mocker.GetMock<IMediator>();

			var requestTest = new GetProductById { Id = products.Id };
			var cancellationToken = new CancellationToken();

			mediator.Setup(x => x.Send(requestTest, cancellationToken)).ReturnsAsync(result);
			handler.Setup(x => x.Handle(requestTest, cancellationToken)).ReturnsAsync(result);

			var controller = _mocker.CreateInstance<ProductController>();

			//Act
			await controller.Get(products.Id);

			//Assert
			handler.Verify(x => x.Handle(requestTest, cancellationToken), Times.Once);
		}

		[Fact]
		public async Task ControllerProducts_GetAll()
		{
			//Arrange
			var pageProducts = new ModelFaker().pageProducts;

			var handler = _mocker.GetMock<IRequestHandler<GetAllProducts, PagesProductsModel>>();
			var mediator = _mocker.GetMock<IMediator>();

			var requestTest = new GetAllProducts { page = 1 };
			var cancellationToken = new CancellationToken();

			mediator.Setup(x => x.Send(requestTest, cancellationToken)).ReturnsAsync(pageProducts);
			handler.Setup(x => x.Handle(requestTest, cancellationToken)).ReturnsAsync(pageProducts);

			var controller = _mocker.CreateInstance<ProductController>();

			//Act
			await controller.Get(1);

			//Assert
			handler.Verify(x => x.Handle(requestTest, cancellationToken), Times.Once);
		}

		[Fact]
		public async Task ControllerProducts_GetByIdWithStorageId()
		{
			//Arrange
			var pageProducts = new ModelFaker().pageProducts;
			var products = new ModelFaker().products;
			var result = _mapper.Map<ProductsMovementModel>(products);

			var handler = _mocker.GetMock<IRequestHandler<GetProductByIdWithStorageId, ProductsMovementModel>>();
			var mediator = _mocker.GetMock<IMediator>();

			var requestTest = new GetProductByIdWithStorageId { Id = products.Id, StorageId = products.StorageId };
			var cancellationToken = new CancellationToken();

			mediator.Setup(x => x.Send(requestTest, cancellationToken)).ReturnsAsync(result);
			handler.Setup(x => x.Handle(requestTest, cancellationToken)).ReturnsAsync(result);

			var controller = _mocker.CreateInstance<ProductController>();

			//Act
			await controller.Get(products.Id, products.StorageId);

			//Assert
			handler.Verify(x => x.Handle(requestTest, cancellationToken), Times.Once);
		}
	}
}
