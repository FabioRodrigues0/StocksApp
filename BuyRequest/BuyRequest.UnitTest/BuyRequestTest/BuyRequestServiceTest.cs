using BuyRequest.Application.Services;
using BuyRequest.Data.Repositories.Interfaces;
using BuyRequest.Domain.Models;
using Infrastructure.Shared.Interfaces;
using Infrastructure.Shared;
using Moq;
using Moq.AutoMock;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;

namespace BuyRequest.UnitTest.BuyRequestTest;

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
		int totalPages = 1, page = 1;
		var list = (buyRequestFaker.listModel, totalPages, page);

		var repository = _mocker.GetMock<IBuyRequestRepository>();
		repository.Setup(x => x.GetAll(page)).ReturnsAsync(list);

		var service = _mocker.CreateInstance<BuyRequestService>();

		//Act
		await service.GetAll(page);

		//Assert
		repository.Verify(x => x.GetAll(page), Times.Once);
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
		repository.Verify(x => x.Add(It.IsAny<BuyRequests>()), Times.Once);
	}

	[Fact]
	public async Task BuyRequestService_Update()
	{
		//Arrange

		#region Vars

		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var repository = _mocker.GetMock<IBuyRequestRepository>();
		var repositoryId = repository.Setup(x => x.GetById(buyRequest.Id)).ReturnsAsync(buyRequest);
		repository.Setup(x => x.Update(buyRequest)).ReturnsAsync(buyRequest);

		var service = _mocker.CreateInstance<BuyRequestService>();

		#endregion Vars

		//Act
		await service.Update(buyRequest);

		//Assert
		repository.Verify(x => x.Update(It.IsAny<BuyRequests>()), Times.Once);
	}

	[Fact]
	public async Task BuyRequestService_Patch()
	{
		//Arrange

		#region Vars

		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var repository = _mocker.GetMock<IBuyRequestRepository>();
		repository.Setup(x => x.GetById(buyRequest.Id)).ReturnsAsync(buyRequest);
		repository.Setup(x => x.Patch(buyRequest));

		var service = _mocker.CreateInstance<BuyRequestService>();

		#endregion Vars

		//Act
		await service.Patch(buyRequest);

		//Assert
		repository.Verify(x => x.Patch(It.IsAny<BuyRequests>()), Times.Once);
	}
}