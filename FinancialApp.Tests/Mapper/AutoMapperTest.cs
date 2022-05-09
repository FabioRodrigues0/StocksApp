using AutoMapper;
using FinancialApp.CrossCutting.Adapter.Map;
using FinancialApp.DTO.DTO;
using FinancialApp.Tests.BuyRequestTest;
using FinancialApp.Tests.CashBookTest;
using FinancialApp.Tests.DocumentTest;
using Moq.AutoMock;
using Shouldly;
using Xunit;

namespace FinancialApp.Tests.Mapper;

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
				x.AddProfile(new BuyRequestAutoMapper());
				x.AddProfile(new BuyRequestProductAutoMapper());
				x.AddProfile(new CashBookAutoMapper());
				x.AddProfile(new DocumentAutoMapper());
			});
			_mapper = mapConfig.CreateMapper();
		}
	}

	[Fact]
	public void AutoMapperBuyRequestProduct()
	{
		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = BuyRequestFaker.buyRequestProducts.Generate();

		var result = _mapper.Map<BuyRequestProductDto>(buyRequest);

		result.ShouldNotBeNull();
		result.ShouldSatisfyAllConditions(
			() => result.ProductDescription.ShouldBe(buyRequest.ProductDescription),
			() => result.ProductCategory.ShouldBe(buyRequest.ProductCategory),
			() => result.Quantity.ShouldBe(buyRequest.Quantity),
			() => result.Valor.ShouldBe(buyRequest.Valor)
			);
	}

	[Fact]
	public void AutoMapperBuyRequest()
	{
		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var result = _mapper.Map<BuyRequestDto>(buyRequest);

		result.ShouldNotBeNull();
		result.ShouldSatisfyAllConditions(
			() => result.Code.ShouldBe(buyRequest.Code),
			() => result.Date.ShouldBe(buyRequest.Date),
			() => result.DeliveryDate.ShouldBe(buyRequest.DeliveryDate),
			() => result.Client.ShouldBe(buyRequest.Client),
			() => result.ClientDescription.ShouldBe(buyRequest.ClientDescription),
			() => result.ClientEmail.ShouldBe(buyRequest.ClientEmail),
			() => result.ClientPhone.ShouldBe(buyRequest.ClientPhone),
			() => result.Status.ShouldBe(buyRequest.Status),
			() => result.Discount.ShouldBe(buyRequest.Discount),
			() => result.Cost.ShouldBe(buyRequest.Cost)
		//() => result.Products.ShouldBeEquivalentTo(buyRequest.Products)
		);
	}

	[Fact]
	public void AutoMapperCashBook()
	{
		var cashBookFaker = new CashBookFaker();
		var cashbook = cashBookFaker.cashbook;

		var result = _mapper.Map<CashBookDto>(cashbook);

		result.ShouldNotBeNull();
		result.ShouldSatisfyAllConditions(
			() => result.Origin.ShouldBe(cashbook.Origin),
			() => result.OriginId.ShouldBe(cashbook.OriginId),
			() => result.Description.ShouldBe(cashbook.Description),
			() => result.Type.ShouldBe(cashbook.Type),
			() => result.Valor.ShouldBe(cashbook.Valor)
		);
	}

	[Fact]
	public void AutoMapperDocument()
	{
		var documentFaker = new DocumentFaker();
		var document = documentFaker.document;

		var result = _mapper.Map<DocumentDto>(document);

		result.ShouldNotBeNull();
		result.ShouldSatisfyAllConditions(
			() => result.Number.ShouldBe(document.Number),
			() => result.Date.ShouldBe(document.Date),
			() => result.Description.ShouldBe(document.Description),
			() => result.Operation.ShouldBe(document.Operation),
			() => result.Observation.ShouldBe(document.Observation),
			() => result.PaymentDate.ShouldBe(document.PaymentDate),
			() => result.DocumentType.ShouldBe(document.DocumentType),
			() => result.Paid.ShouldBe(document.Paid),
			() => result.Total.ShouldBe(document.Total)
		);
	}

	[Fact]
	public void AutoMapperPageBuyRequest()
	{
		var config = new MapperConfiguration(cfg => cfg.AddProfile<PagesBuyRequestMapper>());
		config.AssertConfigurationIsValid();
	}

	[Fact]
	public void AutoMapperPageCashBook()
	{
		var config = new MapperConfiguration(cfg => cfg.AddProfile<PagesCashBookMapper>());
		config.AssertConfigurationIsValid();
	}

	[Fact]
	public void AutoMapperPageDocument()
	{
		var config = new MapperConfiguration(cfg => cfg.AddProfile<PagesDocumentMapper>());
		config.AssertConfigurationIsValid();
	}
}