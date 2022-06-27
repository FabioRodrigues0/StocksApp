using AutoMapper;
using Moq.AutoMock;
using Shouldly;
using Stock.Application.DTO;
using Stock.Application.Map;
using Xunit;

namespace Stocks.UnitTest.AutoMapper
{
	public class AutoMapperTest
	{
		public readonly AutoMocker _mocker;
		private static IMapper _mapper;

		public AutoMapperTest()
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
		public void AutoMapperMovements()
		{
			var modelFaker = new ModelFaker();
			var movements = modelFaker.movements;

			var result = _mapper.Map<MovementsDto>(movements);

			result.ShouldNotBeNull();
			result.ShouldSatisfyAllConditions(
				() => result.Origin.ShouldBe(movements.Origin),
				() => result.OriginId.ShouldBe(movements.OriginId),
				() => result.Date.ShouldBe(movements.Date),
				() => result.Type.ShouldBe(movements.Type)
			);
		}

		[Fact]
		public void AutoMapperProducts()
		{
			var modelFaker = new ModelFaker();
			var products = modelFaker.products;

			var result = _mapper.Map<ProductsMovementDto>(products);

			result.ShouldNotBeNull();
			result.ShouldSatisfyAllConditions(
				() => result.ProductId.ShouldBe(products.ProductId),
				() => result.ProductDescription.ShouldBe(products.ProductDescription),
				() => result.ProductDescription.ShouldBe(products.ProductDescription),
				() => result.Quantity.ShouldBe(products.Quantity),
				() => result.ValorPerUnit.ShouldBe(products.ValorPerUnit),
				() => result.StorageId.ShouldBe(products.StorageId),
				() => result.StorageDescription.ShouldBe(products.StorageDescription)
			);
		}

		[Fact]
		public void AutoMapperPagesMovements()
		{
			var modelFaker = new ModelFaker();
			int totalPages = 1, page = 1;
			var movements = (modelFaker.listMovementsDto, totalPages, page);

			var result = _mapper.Map<PagesMovementsDto>(movements);

			result.ShouldNotBeNull();
		}

		[Fact]
		public void AutoMapperPagesProducts()
		{
			var modelFaker = new ModelFaker();
			int totalPages = 1, page = 1;
			var products = (modelFaker.listProductsDto, totalPages, page);

			var result = _mapper.Map<PagesProductsDto>(products);

			result.ShouldNotBeNull();
		}
	}
}