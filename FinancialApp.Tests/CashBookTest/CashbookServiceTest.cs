using System.Threading.Tasks;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Models;
using FinancialApp.Domain.Services.Services;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace FinancialApp.Tests.CashBookTest;

public class CashBookServiceTest
{
	public readonly AutoMocker _mocker;

	public CashBookServiceTest()
	{
		_mocker = new AutoMocker();
	}

	[Fact]
	public async Task CashBookService_GetAll()
	{
		//Arrange
		var cashBookFaker = new CashBookFaker();
		var cashbook = cashBookFaker.cashbook;

		var repository = _mocker.GetMock<ICashBookRepository>();
		repository.Setup(x => x.GetAll(1));

		var service = _mocker.CreateInstance<CashBookService>();

		//Act
		await service.GetAll(1);

		//Assert
		repository.Verify(x => x.GetAll(1), Times.Once);
	}

	[Fact]
	public async Task CashBookService_GetById()
	{
		//Arrange
		var cashBookFaker = new CashBookFaker();
		var cashbook = cashBookFaker.cashbook;

		var repository = _mocker.GetMock<ICashBookRepository>();
		repository.Setup(x => x.GetById(cashbook.Id));

		var service = _mocker.CreateInstance<CashBookService>();

		//Act
		await service.GetById(cashbook.Id);

		//Assert
		repository.Verify(x => x.GetById(cashbook.Id), Times.Once);
	}

	[Fact]
	public async Task CashBookService_GetByOriginId()
	{
		//Arrange
		var cashBookFaker = new CashBookFaker();
		var cashbook = cashBookFaker.cashbook;

		var repository = _mocker.GetMock<ICashBookRepository>();
		repository.Setup(x => x.GetByOriginId(cashbook.OriginId));

		var service = _mocker.CreateInstance<CashBookService>();

		//Act
		await service.GetByOriginId(cashbook.OriginId);

		//Assert
		repository.Verify(x => x.GetByOriginId(cashbook.OriginId), Times.Once);
	}

	[Fact]
	public async Task CashBookService_Add()
	{
		//Arrange

		#region Vars

		var cashBookFaker = new CashBookFaker();
		var cashbook = cashBookFaker.cashbook;

		var repository = _mocker.GetMock<ICashBookRepository>();
		repository.Setup(x => x.Add(cashbook));

		var service = _mocker.CreateInstance<CashBookService>();

		#endregion Vars

		//Act
		await service.Add(cashbook);

		//Assert
		repository.Verify(x => x.Add(It.IsAny<CashBook>()), Times.Once);
	}

	[Fact]
	public async Task CashBookService_Update()
	{
		//Arrange

		#region Vars

		var cashBookFaker = new CashBookFaker();
		var cashbook = cashBookFaker.cashbook;

		var repository = _mocker.GetMock<ICashBookRepository>();
		repository.Setup(x => x.Update(cashbook));

		var service = _mocker.CreateInstance<CashBookService>();

		#endregion Vars

		//Act
		await service.Update(cashbook);

		//Assert
		repository.Verify(x => x.Update(It.IsAny<CashBook>()), Times.Once);
	}
}