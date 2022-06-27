using AutoMapper;
using MediatR;
using Moq;
using Moq.AutoMock;
using Stock.Api.Controllers;
using Stock.Application.Commands;
using Stock.Application.DTO;
using Stock.Application.Map;
using Stock.Application.Queries;
using Stock.Domain.Models;
using Xunit;

namespace Stocks.UnitTest.Movement
{
	public class ControllerMovementTest
	{
		public readonly AutoMocker _mocker;
		private static IMapper _mapper;
		bool result;
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
			var result = _mapper.Map<MovementsDto>(movements);

			var handler = _mocker.GetMock<IRequestHandler<GetById, MovementsDto>>();
			var mediator = _mocker.GetMock<IMediator>();

			var requestTest = new GetById { Id = movements.Id };
			var cancellationToken = new CancellationToken();

			mediator.Setup(x => x.Send(requestTest, cancellationToken)).ReturnsAsync(result);
			handler.Setup(x => x.Handle(requestTest, cancellationToken)).ReturnsAsync(result);

			var controller = _mocker.CreateInstance<MovementsController>();

			//Act
			controller.Get(movements.Id);

			//Assert
			handler.Verify(x => x.Handle(requestTest, cancellationToken), Times.Once);
		}

		[Fact]
		public async Task ControllerMovement_GetAll()
		{
			//Arrange
			var pageMovements = new ModelFaker().pageMovements;

			var handler = _mocker.GetMock<IRequestHandler<GetAll, PagesMovementsDto>>();
			var mediator = _mocker.GetMock<IMediator>();

			var requestTest = new GetAll { page = 1 };
			var cancellationToken = new CancellationToken();

			mediator.Setup(x => x.Send(requestTest, cancellationToken)).ReturnsAsync(pageMovements);
			handler.Setup(x => x.Handle(requestTest, cancellationToken)).ReturnsAsync(pageMovements);

			var controller = _mocker.CreateInstance<MovementsController>();

			//Act
			controller.Get(1);

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
			controller.Remove(movements.Id);

			//Assert
			handler.Verify(x => x.Handle(requestTest, cancellationToken), Times.Once);
		}

		[Fact]
		public async Task ControllerMovement_Post()
		{
			//Arrange
			var pageProducts = new ModelFaker().pageProducts;
			var movements = new ModelFaker().movements;
			var movementsDto = _mapper.Map<MovementsDto>(movements);

			var handler = _mocker.GetMock<IRequestHandler<Post, Movements>>();
			var mediator = _mocker.GetMock<IMediator>();

			var requestTest = new Post { Movements = movementsDto };
			var cancellationToken = new CancellationToken();

			mediator.Setup(x => x.Send(requestTest, cancellationToken)).ReturnsAsync(movements);
			handler.Setup(x => x.Handle(requestTest, cancellationToken)).ReturnsAsync(movements);

			var controller = _mocker.CreateInstance<MovementsController>();

			//Act
			controller.Post(movementsDto);

			//Assert
			handler.Verify(x => x.Handle(requestTest, cancellationToken), Times.Once);
		}
	}
}
