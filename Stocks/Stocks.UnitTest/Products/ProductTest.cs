using AutoMapper;
using Infrastructure.Shared.Services.Interface;
using Moq;
using Moq.AutoMock;
using Stock.Application.Application.Handlers.Products;
using Stock.Application.Map;
using Stock.Domain.Entities;
using Xunit;

namespace Stocks.UnitTest.Products
{
	public class ProductsTest
	{
		public readonly AutoMocker _mocker;
		private static IMapper _mapper;

		public ProductsTest()
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
		public async Task Model_Product_Validation_Test()
		{
			//Arrange
			var commandFaker = new ModelFaker();
			var products = commandFaker.products;

			var r = _mocker.GetMock<IValidationsBase<ProductsMovement>>();
			var model = _mocker.GetMock<ProductsMovement>();

			r.Setup(x => x.ValidateEntity(products));
			model.Setup(x => x.IsValid());

			var repository = _mocker.CreateInstance<GetProductByIdHandler>();

			//Act
			repository.ValidateEntity(products);

			//Assert
			model.Verify(x => x.IsValid(), Times.Once);
		}
	}
}