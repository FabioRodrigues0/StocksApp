using AutoMapper;
using FinancialApp.API.CashBook.Controllers;
using FinancialApp.Application.Interface;
using FinancialApp.CrossCutting.Adapter.Map;
using FinancialApp.DTO.DTO;
using Moq;
using Moq.AutoMock;
using System.Threading.Tasks;
using Xunit;

namespace FinancialApp.Tests.CashBookTest;

public class CashBookControllerTest
{
	public readonly AutoMocker _mocker;
	private static IMapper _mapper;

	public CashBookControllerTest()
	{
		_mocker = new AutoMocker();
		if (_mapper == null)
		{
			var mapConfig = new MapperConfiguration(x =>
			{
				x.AddProfile(new CashBookAutoMapper());
			});
			_mapper = mapConfig.CreateMapper();
		}
	}

	[Fact]
	public async Task CashBookController_Post()
	{
		// Arrange
		var cashBookFaker = new CashBookFaker();
		var cashBook = cashBookFaker.cashbook;

		var result = _mapper.Map<CashBookDto>(cashBook);

		var application = _mocker.GetMock<IApplicationCashBookService>();
		application.Setup(x => x.Add(result));

		var controller = _mocker.CreateInstance<CashBookController>();

		// Act
		await controller.Post(result);

		// Assert
		application.Verify(x => x.Add(It.IsAny<CashBookDto>()), Times.Once);
	}

	[Fact]
	public async Task CashBookController_Get()
	{
		// Arrange
		var application = _mocker.GetMock<IApplicationCashBookService>();
		application.Setup(x => x.GetAll(1));

		var controller = _mocker.CreateInstance<CashBookController>();

		// Act
		await controller.Get(1);

		// Assert
		application.Verify(x => x.GetAll(1), Times.Once);
	}

	[Fact]
	public async Task CashBookController_Update()
	{
		// Arrange
		var cashBookFaker = new CashBookFaker();
		var cashBook = cashBookFaker.cashbook;

		var result = _mapper.Map<CashBookUpdateDto>(cashBook);

		var application = _mocker.GetMock<IApplicationCashBookService>();
		application.Setup(x => x.Update(result));

		var controller = _mocker.CreateInstance<CashBookController>();

		// Act
		await controller.Put(result);

		// Assert
		application.Verify(x => x.Update(It.IsAny<CashBookUpdateDto>()), Times.Once);
	}

	[Fact]
	public async Task CashBookController_GetById()
	{
		// Arrange
		var cashBookFaker = new CashBookFaker();
		var cashBook = cashBookFaker.cashbook;

		var result = _mapper.Map<CashBookUpdateDto>(cashBook);

		var application = _mocker.GetMock<IApplicationCashBookService>();
		application.Setup(x => x.GetById(result.Id));

		var controller = _mocker.CreateInstance<CashBookController>();

		// Act
		await controller.Get(result.Id);

		// Assert
		application.Verify(x => x.GetById(result.Id), Times.Once);
	}

	[Fact]
	public async Task CashBookController_GetByOriginId()
	{
		// Arrange
		var cashBookFaker = new CashBookFaker();
		var cashBook = cashBookFaker.cashbook;

		var result = _mapper.Map<CashBookUpdateDto>(cashBook);

		var application = _mocker.GetMock<IApplicationCashBookService>();
		application.Setup(x => x.GetByOriginId(result.OriginId));

		var controller = _mocker.CreateInstance<CashBookController>();

		// Act
		await controller.GetOriginId(result.OriginId);

		// Assert
		application.Verify(x => x.GetByOriginId(result.OriginId), Times.Once);
	}
}