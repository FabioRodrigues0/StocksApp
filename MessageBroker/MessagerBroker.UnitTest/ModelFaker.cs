using Bogus;
using Infrastructure.Shared.Enums;
using Stock.Application.DTO;
using Stock.Domain.Models;

namespace MessagerBroker.UnitTest
{
	public class ModelFaker
	{
		public static Faker<ProductsMovement> productsFaker = new Faker<ProductsMovement>()
			.RuleFor(x => x.Id, Guid.NewGuid)
			.RuleFor(x => x.ProductId, Guid.NewGuid)
			.RuleFor(x => x.ProductDescription, x => x.Random.String(1, 256))
			.RuleFor(x => x.ProductCategory, x => x.PickRandom<ProductCategory>())
			.RuleFor(x => x.Quantity, x => x.Random.Int(1, 3))
			.RuleFor(x => x.ValorPerUnit, x => x.Random.Decimal(1, 30))
			.RuleFor(x => x.StorageId, Guid.NewGuid)
			.RuleFor(x => x.StorageDescription, x => x.Random.String(1, 256));

		public ProductsMovement products = new Faker<ProductsMovement>()
			.RuleFor(x => x.Id, Guid.NewGuid)
			.RuleFor(x => x.ProductId, Guid.NewGuid)
			.RuleFor(x => x.ProductDescription, x => x.Random.String(1, 256))
			.RuleFor(x => x.ProductCategory, x => x.PickRandom<ProductCategory>())
			.RuleFor(x => x.Quantity, x => x.Random.Int(1, 3))
			.RuleFor(x => x.ValorPerUnit, x => x.Random.Decimal(1, 30))
			.RuleFor(x => x.StorageId, Guid.NewGuid)
			.RuleFor(x => x.StorageDescription, x => x.Random.String(1, 256));

		public static Faker<ProductsMovementDto> productsDto = new Faker<ProductsMovementDto>()
			.RuleFor(x => x.ProductId, Guid.NewGuid)
			.RuleFor(x => x.ProductDescription, x => x.Random.String(1, 256))
			.RuleFor(x => x.ProductCategory, x => x.PickRandom<ProductCategory>())
			.RuleFor(x => x.Quantity, x => x.Random.Int(1, 3))
			.RuleFor(x => x.ValorPerUnit, x => x.Random.Decimal(1, 30))
			.RuleFor(x => x.StorageId, Guid.NewGuid)
			.RuleFor(x => x.StorageDescription, x => x.Random.String(1, 256));

		public MovementsDto movementsDto = new Faker<MovementsDto>()
			.RuleFor(x => x.Origin, x => Origin.BuyRequest)
			.RuleFor(x => x.OriginId, Guid.NewGuid)
			.RuleFor(x => x.Date, DateTimeOffset.Now.AddDays(6))
			.RuleFor(x => x.Type, x => x.PickRandom<Operation>())
			.RuleFor(x => x.ProductsMovements, x => productsDto.GenerateBetween(1, 3));

		public static Faker<MovementsDto> movementsDtoFaker = new Faker<MovementsDto>()
			.RuleFor(x => x.Origin, x => Origin.BuyRequest)
			.RuleFor(x => x.OriginId, Guid.NewGuid)
			.RuleFor(x => x.Date, DateTimeOffset.Now.AddDays(6))
			.RuleFor(x => x.Type, x => x.PickRandom<Operation>())
			.RuleFor(x => x.ProductsMovements, x => productsDto.GenerateBetween(1, 3));

		public Movements movements = new Faker<Movements>()
			.RuleFor(x => x.Id, Guid.NewGuid)
			.RuleFor(x => x.Origin, x => Origin.BuyRequest)
			.RuleFor(x => x.OriginId, Guid.NewGuid)
			.RuleFor(x => x.Date, DateTimeOffset.Now.AddDays(6))
			.RuleFor(x => x.Type, x => x.PickRandom<Operation>())
			.RuleFor(x => x.ProductsMovements, x => productsFaker.GenerateBetween(1, 3));

		public PagesMovementsDto pageMovements = new Faker<PagesMovementsDto>()
			.RuleFor(x => x.Models, x => movementsDtoFaker.GenerateBetween(1, 3))
			.RuleFor(x => x.CurrentPage, 1)
			.RuleFor(x => x.Pages, 1);

		public PagesProductsDto pageProducts = new Faker<PagesProductsDto>()
			.RuleFor(x => x.Models, x => productsDto.GenerateBetween(1, 3))
			.RuleFor(x => x.CurrentPage, 1)
			.RuleFor(x => x.Pages, 1);

		public List<ProductsMovementDto> listProductsDto = new Faker<ProductsMovementDto>()
			.RuleFor(x => x.ProductId, Guid.NewGuid)
			.RuleFor(x => x.ProductDescription, x => x.Random.String(1, 256))
			.RuleFor(x => x.ProductCategory, x => x.PickRandom<ProductCategory>())
			.RuleFor(x => x.Quantity, x => x.Random.Int(1, 3))
			.RuleFor(x => x.ValorPerUnit, x => x.Random.Decimal(1, 30))
			.RuleFor(x => x.StorageId, Guid.NewGuid)
			.RuleFor(x => x.StorageDescription, x => x.Random.String(1, 256))
			.GenerateBetween(1, 3);

		public List<ProductsMovement> listProductsModel = new Faker<ProductsMovement>()
			.RuleFor(x => x.Id, Guid.NewGuid)
			.RuleFor(x => x.ProductId, Guid.NewGuid)
			.RuleFor(x => x.ProductDescription, x => x.Random.String(1, 256))
			.RuleFor(x => x.ProductCategory, x => x.PickRandom<ProductCategory>())
			.RuleFor(x => x.Quantity, x => x.Random.Int(1, 3))
			.RuleFor(x => x.ValorPerUnit, x => x.Random.Decimal(1, 30))
			.RuleFor(x => x.StorageId, Guid.NewGuid)
			.RuleFor(x => x.StorageDescription, x => x.Random.String(1, 256))
			.GenerateBetween(1, 3);

		public List<MovementsDto> listMovementsDto = new Faker<MovementsDto>()
			.RuleFor(x => x.Origin, x => Origin.BuyRequest)
			.RuleFor(x => x.OriginId, Guid.NewGuid)
			.RuleFor(x => x.Date, DateTimeOffset.Now.AddDays(6))
			.RuleFor(x => x.Type, x => x.PickRandom<Operation>())
			.RuleFor(x => x.ProductsMovements, x => productsDto.GenerateBetween(1, 3))
			.GenerateBetween(1, 3);

		public List<Movements> listMovementsModel = new Faker<Movements>()
			.RuleFor(x => x.Id, Guid.NewGuid)
			.RuleFor(x => x.Origin, x => Origin.BuyRequest)
			.RuleFor(x => x.OriginId, Guid.NewGuid)
			.RuleFor(x => x.Date, DateTimeOffset.Now.AddDays(6))
			.RuleFor(x => x.Type, x => x.PickRandom<Operation>())
			.RuleFor(x => x.ProductsMovements, x => productsFaker.GenerateBetween(1, 3))
			.GenerateBetween(1, 3);
	}
}