using AutoMapper;
using Infrastructure.Shared.Entities;
using Moq;
using Moq.AutoMock;
using Stock.Application.Application.Handlers.Products;
using Stock.Application.Map;
using Stock.Application.Queries;
using Stock.Data.Repositories.Interfaces;
using Stock.Domain.Entities;
using Xunit;

namespace Stocks.UnitTest.Products
{
	public class QueryProductsTest
	{
		public readonly AutoMocker _mocker;
		private static IMapper _mapper;

		public QueryProductsTest()
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
		public async Task Query_GetAllProducts()
		{
			//Arrange
			var commandFaker = new ModelFaker();
			var producsts = new PagesBase<ProductsMovement>();

			var repository = _mocker.GetMock<IProductsMovementRepository>();

			repository.Setup(x => x.GetAllAsync(1, 10)).ReturnsAsync(producsts);

			var handler = _mocker.CreateInstance<GetAllProductsHandler>();
			var requestTest = new GetAllProducts { page = 1, itemsPerPage = 10 };
			var cancellationToken = new CancellationToken();

			//Act
			await handler.Handle(requestTest, cancellationToken);

			//Assert
			repository.Verify(x => x.GetAllAsync(1, 10), Times.Once);
		}

		[Fact]
		public async Task Query_GetProductById()
		{
			//Arrange
			var commandFaker = new ModelFaker();
			var products = commandFaker.products;

			var repository = _mocker.GetMock<IProductsMovementRepository>();

			repository.Setup(x => x.GetByIdAsync(products.Id)).ReturnsAsync(products);

			var handler = _mocker.CreateInstance<GetProductByIdHandler>();
			var requestTest = new GetProductById { Id = products.Id };
			var cancellationToken = new CancellationToken();

			//Act
			await handler.Handle(requestTest, cancellationToken);

			//Assert
			repository.Verify(x => x.GetByIdAsync(products.Id), Times.Once);
		}

		[Fact]
		public async Task Query_GetProductByIdWithStorageId()
		{
			//Arrange
			var commandFaker = new ModelFaker();
			var products = commandFaker.products;

			var repository = _mocker.GetMock<IProductsMovementRepository>();

			repository.Setup(x => x.GetByIdWithStorageIdAsync(products.Id, products.StorageId)).ReturnsAsync(products);

			var handler = _mocker.CreateInstance<GetProductByIdWithStorageIdHandler>();
			var requestTest = new GetProductByIdWithStorageId { Id = products.Id, StorageId = products.StorageId };
			var cancellationToken = new CancellationToken();

			//Act
			await handler.Handle(requestTest, cancellationToken);

			//Assert
			repository.Verify(x => x.GetByIdWithStorageIdAsync(products.Id, products.StorageId), Times.Once);
		}

		[Fact]
		public async Task Query_GetAllProducts_NoContent()
		{
			//Arrange
			var commandFaker = new ModelFaker();
			var list = new List<ProductsMovement>();
			int totalPages = 1, page = 1;
			var producsts = new PagesBase<ProductsMovement>();

			var repository = _mocker.GetMock<IProductsMovementRepository>();

			repository.Setup(x => x.GetAllAsync(1, 10)).ReturnsAsync(producsts);

			var handler = _mocker.CreateInstance<GetAllProductsHandler>();
			var requestTest = new GetAllProducts { page = 1, itemsPerPage = 10 };
			var cancellationToken = new CancellationToken();

			//Act
			await handler.Handle(requestTest, cancellationToken);

			//Assert
			repository.Verify(x => x.GetAllAsync(1, 10), Times.Once);
		}

		[Fact]
		public async Task Query_GetProductById_NoContent()
		{
			//Arrange
			var commandFaker = new ModelFaker();
			var products = commandFaker.products;
			var productsNoContent = new ProductsMovement();
			productsNoContent = null;

			var repository = _mocker.GetMock<IProductsMovementRepository>();

			repository.Setup(x => x.GetByIdAsync(products.Id)).ReturnsAsync(productsNoContent);

			var handler = _mocker.CreateInstance<GetProductByIdHandler>();
			var requestTest = new GetProductById { Id = products.Id };
			var cancellationToken = new CancellationToken();

			//Act
			await handler.Handle(requestTest, cancellationToken);

			//Assert
			repository.Verify(x => x.GetByIdAsync(products.Id), Times.Once);
		}

		[Fact]
		public async Task Query_GetProductByIdWithStorageId_NoContent()
		{
			//Arrange
			var commandFaker = new ModelFaker();
			var products = commandFaker.products;
			var productsNoContent = new ProductsMovement();
			productsNoContent = null;

			var repository = _mocker.GetMock<IProductsMovementRepository>();

			repository.Setup(x => x.GetByIdWithStorageIdAsync(products.Id, products.StorageId)).ReturnsAsync(productsNoContent);

			var handler = _mocker.CreateInstance<GetProductByIdWithStorageIdHandler>();
			var requestTest = new GetProductByIdWithStorageId { Id = products.Id, StorageId = products.StorageId };
			var cancellationToken = new CancellationToken();

			//Act
			await handler.Handle(requestTest, cancellationToken);

			//Assert
			repository.Verify(x => x.GetByIdWithStorageIdAsync(products.Id, products.StorageId), Times.Once);
		}
	}
}