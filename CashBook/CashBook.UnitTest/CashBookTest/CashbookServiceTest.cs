using CashBook.Application.Services;
using CashBook.Data.Repositories.Interfaces;
using CashBook.Domain.Models;
using Moq;
using Moq.AutoMock;
using System.Threading.Tasks;
using Xunit;

namespace CashBook.UnitTest.CashBookTest;

public class CashBookServiceTest
{
	public readonly AutoMocker Mocker;

	public CashBookServiceTest()
	{
		Mocker = new AutoMocker();
	}

	[Fact]
	public async Task CashBookService_GetAll()
	{
		//Arrange
		var cashBookFaker = new CashBookFaker();
		var cashbook = cashBookFaker.cashbook;

		var repository = Mocker.GetMock<ICashBookRepository>();
		int totalPages = 1, page = 1;
		var list = (cashBookFaker.listModel, totalPages, page); ;
		repository.Setup(x => x.GetAll(page)).ReturnsAsync(list);

		var service = Mocker.CreateInstance<CashBookService>();

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

		var repository = Mocker.GetMock<ICashBookRepository>();
		repository.Setup(x => x.GetById(cashbook.Id));

		var service = Mocker.CreateInstance<CashBookService>();

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

		var repository = Mocker.GetMock<ICashBookRepository>();
		repository.Setup(x => x.GetByOriginId(cashbook.OriginId));

		var service = Mocker.CreateInstance<CashBookService>();

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

		var repository = Mocker.GetMock<ICashBookRepository>();
		repository.Setup(x => x.Add(cashbook));

		var service = Mocker.CreateInstance<CashBookService>();

		#endregion Vars

		//Act
		await service.Add(cashbook);

		//Assert
		repository.Verify(x => x.Add(It.IsAny<CashBooks>()), Times.Once);
	}

	[Fact]
	public async Task CashBookService_Update()
	{
		//Arrange

		#region Vars

		var cashBookFaker = new CashBookFaker();
		var cashbook = cashBookFaker.cashbook;

		var repository = Mocker.GetMock<ICashBookRepository>();
		repository.Setup(x => x.GetById(cashbook.Id)).ReturnsAsync(cashbook);
		repository.Setup(x => x.Update(cashbook));

		var test = repository.Setups;

		var service = Mocker.CreateInstance<CashBookService>();

		#endregion Vars

		//Act
		await service.Update(cashbook);

		//Assert
		repository.Verify(x => x.Update(It.IsAny<CashBooks>()), Times.Once);
	}
}