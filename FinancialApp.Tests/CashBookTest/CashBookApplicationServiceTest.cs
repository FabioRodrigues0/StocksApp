using System.Collections.Generic;
using AutoMapper;
using FinancialApp.Application.Service;
using FinancialApp.CrossCutting.Adapter.Map;
using FinancialApp.Domain.Core.Services;
using FinancialApp.Domain.Models;
using FinancialApp.DTO.DTO;
using Moq;
using Moq.AutoMock;
using System.Threading.Tasks;
using Xunit;

namespace FinancialApp.Tests.CashBookTest;

public class CashBookApplicationServiceTest
{
	public readonly AutoMocker Mocker;
	private static IMapper _mapper;

	public CashBookApplicationServiceTest()
	{
		Mocker = new AutoMocker();
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
	public async Task CashBookApplicationService_GetAll()
	{
		//Arrange
		var cashBookFaker = new CashBookFaker();
		var cashbook = cashBookFaker.cashbook;
		var list = new List<CashBook>();

		var repository = Mocker.GetMock<ICashBookService>();
		repository.Setup(x => x.GetAll()).ReturnsAsync(list);

		var service = Mocker.CreateInstance<ApplicationCashBookService>();

		//Act
		await service.GetAll(1);

		//Assert
		repository.Verify(x => x.GetAll(), Times.Once);
	}

	[Fact]
	public async Task CashBookApplicationService_GetById()
	{
		//Arrange
		var cashBookFaker = new CashBookFaker();
		var cashbook = cashBookFaker.cashbook;

		var repository = Mocker.GetMock<ICashBookService>();
		repository.Setup(x => x.GetById(cashbook.Id));

		var service = Mocker.CreateInstance<ApplicationCashBookService>();

		//Act
		await service.GetById(cashbook.Id);

		//Assert
		repository.Verify(x => x.GetById(cashbook.Id), Times.Once);
	}

	[Fact]
	public async Task CashBookApplicationService_GetByOriginId()
	{
		//Arrange
		var cashBookFaker = new CashBookFaker();
		var cashbook = cashBookFaker.cashbook;

		var repository = Mocker.GetMock<ICashBookService>();
		repository.Setup(x => x.GetByOriginId(cashbook.OriginId));

		var service = Mocker.CreateInstance<ApplicationCashBookService>();

		//Act
		await service.GetByOriginId(cashbook.OriginId);

		//Assert
		repository.Verify(x => x.GetByOriginId(cashbook.OriginId), Times.Once);
	}

	[Fact]
	public async Task CashBookApplicationService_Add()
	{
		//Arrange

		#region Vars

		var cashBookFaker = new CashBookFaker();
		var cashbook = cashBookFaker.cashbook;

		var result = _mapper.Map<CashBookDto>(cashbook);

		var repository = Mocker.GetMock<ICashBookService>();
		repository.Setup(x => x.Add(cashbook));

		var service = Mocker.CreateInstance<ApplicationCashBookService>();

		#endregion Vars

		//Act
		await service.Add(result);

		//Assert
		repository.Verify(x => x.Add(It.IsAny<CashBook>()), Times.Once);
	}

	[Fact]
	public async Task CashBookApplicationService_Update()
	{
		//Arrange

		#region Vars

		var cashBookFaker = new CashBookFaker();
		var cashbook = cashBookFaker.cashbook;

		var result = _mapper.Map<CashBookUpdateDto>(cashbook);

		var repository = Mocker.GetMock<ICashBookService>();
		repository.Setup(x => x.GetById(cashbook.Id)).ReturnsAsync(cashbook);
		repository.Setup(x => x.Update(cashbook));

		var service = Mocker.CreateInstance<ApplicationCashBookService>();

		#endregion Vars

		//Act
		await service.Update(result);

		//Assert
		repository.Verify(x => x.Update(It.IsAny<CashBook>()), Times.Once);
	}
}