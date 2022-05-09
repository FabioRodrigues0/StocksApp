using System.Collections.Generic;
using AutoMapper;
using FinancialApp.Application.Service;
using FinancialApp.CrossCutting.Adapter.Map;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Core.Services;
using FinancialApp.Domain.Models;
using FinancialApp.Domain.Services.Services;
using FinancialApp.DTO.DTO;
using Moq;
using Moq.AutoMock;
using System.Threading.Tasks;
using Xunit;

namespace FinancialApp.Tests.BuyRequestTest;

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
		var page = buyRequestFaker.pageBuyRequest;
		var list = new List<BuyRequest>();

		var repository = _mocker.GetMock<IBuyRequestService>();
		repository.Setup(x => x.GetAll()).ReturnsAsync(list);

		var service = _mocker.CreateInstance<ApplicationBuyRequestService>();

		//Act
		await service.GetAll(1);

		//Assert
		repository.Verify(x => x.GetAll(), Times.Once);
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
		repository.Verify(x => x.Add(It.IsAny<BuyRequest>()), Times.Once);
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
		repository.Verify(x => x.Update(It.IsAny<BuyRequest>()), Times.Once);
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
		repository.Verify(x => x.Patch(It.IsAny<BuyRequest>()), Times.Once);
	}
}