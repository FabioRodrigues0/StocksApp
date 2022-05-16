using System.Threading.Tasks;
using AutoMapper;
using BuyRequest.Api.Controllers;
using BuyRequest.Application.Application.Interface;
using BuyRequest.Application.DTO;
using BuyRequest.Application.Map;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace BuyRequest.UnitTest.BuyRequestTest;

public class DocumentControllerTest
{
	public readonly AutoMocker _mocker;
	private static IMapper _mapper;

	public DocumentControllerTest()
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
	public async Task BuyRequestController_Post()
	{
		// Arrange
		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var result = _mapper.Map<BuyRequestDto>(buyRequest);

		var application = _mocker.GetMock<IApplicationBuyRequestService>();
		application.Setup(x => x.Add(result));

		var controller = _mocker.CreateInstance<BuyRequestController>();

		// Act
		await controller.Post(result);

		// Assert
		application.Verify(x => x.Add(It.IsAny<BuyRequestDto>()), Times.Once);
	}

	[Fact]
	public async Task BuyRequestController_Get()
	{
		// Arrange
		var application = _mocker.GetMock<IApplicationBuyRequestService>();
		application.Setup(x => x.GetAll(1));

		var controller = _mocker.CreateInstance<BuyRequestController>();

		// Act
		await controller.Get(1);

		// Assert
		application.Verify(x => x.GetAll(1), Times.Once);
	}

	[Fact]
	public async Task BuyRequestController_Update()
	{
		// Arrange
		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var result = _mapper.Map<BuyRequestUpdateDto>(buyRequest);

		var application = _mocker.GetMock<IApplicationBuyRequestService>();
		application.Setup(x => x.Update(result));

		var controller = _mocker.CreateInstance<BuyRequestController>();

		// Act
		await controller.Put(result);

		// Assert
		application.Verify(x => x.Update(It.IsAny<BuyRequestUpdateDto>()), Times.Once);
	}

	[Fact]
	public async Task BuyRequestController_Patch()
	{
		// Arrange
		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var result = _mapper.Map<BuyRequestPatchDto>(buyRequest);

		var application = _mocker.GetMock<IApplicationBuyRequestService>();
		application.Setup(x => x.Patch(result));

		var controller = _mocker.CreateInstance<BuyRequestController>();

		// Act
		await controller.Patch(result);

		// Assert
		application.Verify(x => x.Patch(It.IsAny<BuyRequestPatchDto>()), Times.Once);
	}

	[Fact]
	public async Task BuyRequestController_Remove()
	{
		// Arrange
		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var result = _mapper.Map<BuyRequestUpdateDto>(buyRequest);

		var application = _mocker.GetMock<IApplicationBuyRequestService>();
		application.Setup(x => x.Remove(result.Id));

		var controller = _mocker.CreateInstance<BuyRequestController>();

		// Act
		await controller.Delete(result.Id);

		// Assert
		application.Verify(x => x.Remove(result.Id), Times.Once);
	}

	[Fact]
	public async Task BuyRequestController_GetById()
	{
		// Arrange
		var buyRequestFaker = new BuyRequestFaker();
		var buyRequest = buyRequestFaker.buyRequest;

		var result = _mapper.Map<BuyRequestUpdateDto>(buyRequest);

		var application = _mocker.GetMock<IApplicationBuyRequestService>();
		application.Setup(x => x.GetById(result.Id));

		var controller = _mocker.CreateInstance<BuyRequestController>();

		// Act
		await controller.Get(result.Id);

		// Assert
		application.Verify(x => x.GetById(result.Id), Times.Once);
	}
}