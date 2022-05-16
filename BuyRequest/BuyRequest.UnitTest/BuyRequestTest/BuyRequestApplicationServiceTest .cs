using System.Collections.Generic;
using AutoMapper;
using Moq;
using Moq.AutoMock;
using System.Threading.Tasks;
using Xunit;
using BuyRequest.Application.Map;
using BuyRequest.Application.Services.Interfaces;
using BuyRequest.Application.Application;
using BuyRequest.Domain.Models;
using BuyRequest.Application.DTO;

namespace BuyRequest.UnitTest.BuyRequestTest;

public class BuyRequestApplicationServiceTest
{
	public readonly AutoMocker _mocker;
	private static IMapper _mapper;

	public BuyRequestApplicationServiceTest()
	{
		_mocker = new AutoMocker();
		if (_mapper == null)
		{
			var mapConfig = new MapperConfiguration(x =>
			{
				x.AddProfile(new BuyRequestAutoMapper());
				x.AddProfile(new BuyRequestProductAutoMapper());
			});
			_mapper = mapConfig.CreateMapper();
		}
	}

	[Fact]
	public async Task BuyRequestApplicationService_GetAll()
	{
		//Arrange
		var buyRequestFaker = new BuyRequestFaker();
		var pageBuyRequest = buyRequestFaker.pageBuyRequest;
		int totalPages = 1, page = 1;
		var list = (new List<BuyRequests>(), totalPages, page);

		var repository = _mocker.GetMock<IBuyRequestService>();
		repository.Setup(x => x.GetAll(page)).ReturnsAsync(list);

		var service = _mocker.CreateInstance<ApplicationBuyRequestService>();

		//Act
		await service.GetAll(page);

		//Assert
		repository.Verify(x => x.GetAll(page), Times.Once);
	}

	[Fact]
	public async Task BuyRequestApplicationService_GetById()
	{
		//Arrange
		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var repository = _mocker.GetMock<IBuyRequestService>();
		repository.Setup(x => x.GetById(buyRequest.Id));

		var service = _mocker.CreateInstance<ApplicationBuyRequestService>();

		//Act
		await service.GetById(buyRequest.Id);

		//Assert
		repository.Verify(x => x.GetById(buyRequest.Id), Times.Once);
	}

	[Fact]
	public async Task BuyRequestApplicationService_GetByIdWithClient()
	{
		//Arrange
		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var repository = _mocker.GetMock<IBuyRequestService>();
		repository.Setup(x => x.GetById(buyRequest.Client));

		var service = _mocker.CreateInstance<ApplicationBuyRequestService>();

		//Act
		await service.GetById(buyRequest.Client);

		//Assert
		repository.Verify(x => x.GetById(buyRequest.Client), Times.Once);
	}

	[Fact]
	public async Task BuyRequestApplicationService_Add()
	{
		//Arrange

		#region Vars

		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var result = _mapper.Map<BuyRequestDto>(buyRequest);

		var repository = _mocker.GetMock<IBuyRequestService>();
		repository.Setup(x => x.Add(buyRequest));

		var service = _mocker.CreateInstance<ApplicationBuyRequestService>();

		#endregion Vars

		//Act
		await service.Add(result);

		//Assert
		repository.Verify(x => x.Add(It.IsAny<BuyRequests>()), Times.Once);
	}

	[Fact]
	public async Task BuyRequestApplicationService_Update()
	{
		//Arrange

		#region Vars

		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var result = _mapper.Map<BuyRequestUpdateDto>(buyRequest);

		var repository = _mocker.GetMock<IBuyRequestService>();
		repository.Setup(x => x.GetById(buyRequest.Id)).ReturnsAsync(buyRequest);
		repository.Setup(x => x.Update(buyRequest));

		var service = _mocker.CreateInstance<ApplicationBuyRequestService>();

		#endregion Vars

		//Act
		await service.Update(result);

		//Assert
		repository.Verify(x => x.Update(It.IsAny<BuyRequests>()), Times.Once);
	}

	[Fact]
	public async Task BuyRequestApplicationService_Patch()
	{
		//Arrange

		#region Vars

		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var result = _mapper.Map<BuyRequestPatchDto>(buyRequest);

		var repository = _mocker.GetMock<IBuyRequestService>();
		repository.Setup(x => x.GetById(buyRequest.Id)).ReturnsAsync(buyRequest);
		repository.Setup(x => x.Patch(buyRequest));

		var service = _mocker.CreateInstance<ApplicationBuyRequestService>();

		#endregion Vars

		//Act
		await service.Patch(result);

		//Assert
		repository.Verify(x => x.Patch(It.IsAny<BuyRequests>()), Times.Once);
	}
}