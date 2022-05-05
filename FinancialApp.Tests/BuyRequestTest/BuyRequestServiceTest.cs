using System.Threading.Tasks;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Models;
using FinancialApp.Domain.Services.Services;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace FinancialApp.Tests.BuyRequestTest;

public class BuyRequestServiceTest
{
	public readonly AutoMocker _mocker;

	public BuyRequestServiceTest()
	{
		_mocker = new AutoMocker();
	}

	[Fact]
	public async Task BuyRequestService_GetAll()
	{
		//Arrange
		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var repository = _mocker.GetMock<IBuyRequestRepository>();
		repository.Setup(x => x.GetAll(1));

		var service = _mocker.CreateInstance<BuyRequestService>();

		//Act
		await service.GetAll(1);

		//Assert
		repository.Verify(x => x.GetAll(1), Times.Once);
	}

	[Fact]
	public async Task BuyRequestService_GetById()
	{
		//Arrange
		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var repository = _mocker.GetMock<IBuyRequestRepository>();
		repository.Setup(x => x.GetById(buyRequest.Id));

		var service = _mocker.CreateInstance<BuyRequestService>();

		//Act
		await service.GetById(buyRequest.Id);

		//Assert
		repository.Verify(x => x.GetById(buyRequest.Id), Times.Once);
	}

	[Fact]
	public async Task BuyRequestService_GetByIdWithClient()
	{
		//Arrange
		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var repository = _mocker.GetMock<IBuyRequestRepository>();
		repository.Setup(x => x.GetById(buyRequest.Client));

		var service = _mocker.CreateInstance<BuyRequestService>();

		//Act
		await service.GetById(buyRequest.Client);

		//Assert
		repository.Verify(x => x.GetById(buyRequest.Client), Times.Once);
	}

	[Fact]
	public async Task BuyRequestService_Add()
	{
		//Arrange

		#region Vars

		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var repository = _mocker.GetMock<IBuyRequestRepository>();
		repository.Setup(x => x.Add(buyRequest));

		var service = _mocker.CreateInstance<BuyRequestService>();

		#endregion Vars

		//Act
		await service.Add(buyRequest);

		//Assert
		repository.Verify(x => x.Add(It.IsAny<BuyRequest>()), Times.Once);
	}

	[Fact]
	public async Task BuyRequestService_Update()
	{
		//Arrange

		#region Vars

		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var repository = _mocker.GetMock<IBuyRequestRepository>();
		repository.Setup(x => x.Update(buyRequest));

		var service = _mocker.CreateInstance<BuyRequestService>();

		#endregion Vars

		//Act
		await service.Update(buyRequest);

		//Assert
		repository.Verify(x => x.Update(It.IsAny<BuyRequest>()), Times.Once);
	}

	[Fact]
	public async Task BuyRequestService_Patch()
	{
		//Arrange

		#region Vars

		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var repository = _mocker.GetMock<IBuyRequestRepository>();
		repository.Setup(x => x.Patch(buyRequest));

		var service = _mocker.CreateInstance<BuyRequestService>();

		#endregion Vars

		//Act
		await service.Patch(buyRequest);

		//Assert
		repository.Verify(x => x.Patch(It.IsAny<BuyRequest>()), Times.Once);
	}
}