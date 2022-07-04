using AutoMapper;
using MediatR;
using Moq;
using Moq.AutoMock;
using Stock.Api.Controllers;
using Stock.Application.Commands;
using Stock.Application.Map;
using Stock.Application.Models;
using Stock.Application.Queries;
using Stock.Domain.Entities;
using Xunit;

namespace Stocks.UnitTest.Movement
{
	public class ControllerMovementTest
	{
		public readonly AutoMocker _mocker;
		private static IMapper _mapper;
		private bool result;

		public ControllerMovementTest()
		{
			_mocker = new AutoMocker();
			if (_mapper == null)
			{
				var mapConfig = new MapperConfiguration(x =>
				{
					x.AddProfile(new MovementAutomapper());
					x.AddProfile(new ProductsMovementAutomapper());
					x.AddProfile(new PagesMapper());
				});
				_mapper = mapConfig.CreateMapper();
			}
		}

		[Fact]
		public async Task ControllerMovement_GetById()
		{
			//Arrange
			var pageProducts = new ModelFaker().pageProducts;
			var movements = new ModelFaker().movements;
			var result = _mapper.Map<MovementsModel>(movements);

			var handler = _mocker.GetMock<IRequestHandler<GetById, MovementsModel>>();
			var mediator = _mocker.GetMock<IMediator>();

			var requestTest = new GetById { Id = movements.Id };
			var cancellationToken = new CancellationToken();

			mediator.Setup(x => x.Send(requestTest, cancellationToken)).ReturnsAsync(result);
			handler.Setup(x => x.Handle(requestTest, cancellationToken)).ReturnsAsync(result);

			var controller = _mocker.CreateInstance<MovementsController>();

			//Act
			await controller.Get(movements.Id);

			//Assert
			handler.Verify(x => x.Handle(requestTest, cancellationToken), Times.Once);
		}

		[Fact]
		public async Task ControllerMovement_GetAll()
		{
			//Arrange
			var pageMovements = new ModelFaker().pageMovements;

			var handler = _mocker.GetMock<IRequestHandler<GetAll, PagesMovementsModel>>();
			var mediator = _mocker.GetMock<IMediator>();

			var requestTest = new GetAll { page = 1 };
			var cancellationToken = new CancellationToken();

			mediator.Setup(x => x.Send(requestTest, cancellationToken)).ReturnsAsync(pageMovements);
			handler.Setup(x => x.Handle(requestTest, cancellationToken)).ReturnsAsync(pageMovements);

			var controller = _mocker.CreateInstance<MovementsController>();

			//Act
			await controller.Get(1);

			//Assert
			handler.Verify(x => x.Handle(requestTest, cancellationToken), Times.Once);
		}

		[Fact]
		public async Task ControllerMovement_Remove()
		{
			//Arrange
			var pageProducts = new ModelFaker().pageProducts;
			var movements = new ModelFaker().movements;

			var handler = _mocker.GetMock<IRequestHandler<Delete, bool>>();
			var mediator = _mocker.GetMock<IMediator>();

			var requestTest = new Delete { Id = movements.Id };
			var cancellationToken = new CancellationToken();

			mediator.Setup(x => x.Send(requestTest, cancellationToken)).ReturnsAsync(result);
			handler.Setup(x => x.Handle(requestTest, cancellationToken)).ReturnsAsync(result);

			var controller = _mocker.CreateInstance<MovementsController>();

			//Act
			await controller.Remove(movements.Id);

			//Assert
			handler.Verify(x => x.Handle(requestTest, cancellationToken), Times.Once);
		}

		[Fact]
		public async Task ControllerMovement_Post()
		{
			//Arrange
			var pageProducts = new ModelFaker().pageProducts;
			var movements = new ModelFaker().movements;
			var movementsDto = _mapper.Map<MovementsModel>(movements);

			var handler = _mocker.GetMock<IRequestHandler<Post, Movements>>();
			var mediator = _mocker.GetMock<IMediator>();

			var requestTest = new Post { Movements = movementsDto };
			var cancellationToken = new CancellationToken();

			mediator.Setup(x => x.Send(requestTest, cancellationToken)).ReturnsAsync(movements);
			handler.Setup(x => x.Handle(requestTest, cancellationToken)).ReturnsAsync(movements);

			var controller = _mocker.CreateInstance<MovementsController>();

			//Act
			await controller.Post(movementsDto);

			//Assert
			handler.Verify(x => x.Handle(requestTest, cancellationToken), Times.Once);
		}
	}
}