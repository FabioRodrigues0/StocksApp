using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bogus;
using FinancialApp.API.BuyRequest.Controllers;
using FinancialApp.Application.Interface;
using FinancialApp.CrossCutting.Adapter.Map;
using FinancialApp.Data;
using FinancialApp.Domain.Models;
using FinancialApp.DTO.DTO;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace FinancialApp.Tests.BuyRequestTest;

public class BuyRequestControllerTest
{
    public readonly AutoMocker _mocker;
    private static IMapper _mapper;

    public BuyRequestControllerTest()
    {
        _mocker = new AutoMocker();
        if(_mapper == null)
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
}