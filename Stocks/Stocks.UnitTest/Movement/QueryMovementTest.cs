using AutoMapper;
using Infrastructure.Shared.Entities;
using Moq;
using Moq.AutoMock;
using Stock.Application.Application.Handlers.Movement;
using Stock.Application.Map;
using Stock.Application.Models;
using Stock.Application.Queries;
using Stock.Data.Repositories.Interfaces;
using Stock.Domain.Entities;
using Xunit;

namespace Stocks.UnitTest.Movement
{
	public class QueryMovementTest
	{
		public readonly AutoMocker _mocker;
		private static IMapper _mapper;

		public QueryMovementTest()
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
		public async Task Query_GetAll()
		{
			//Arrange
			var commandFaker = new ModelFaker();
			var movements = new PagesBase<Movements>();

			var repository = _mocker.GetMock<IMovementsRepository>();

			repository.Setup(x => x.GetAllAsync(1, 10)).ReturnsAsync(movements);

			var handler = _mocker.CreateInstance<GetAllHandler>();
			var requestTest = new GetAll { page = 1, itemsPerPage = 10 };
			var cancellationToken = new CancellationToken();

			//Act
			await handler.Handle(requestTest, cancellationToken);

			//Assert
			repository.Verify(x => x.GetAllAsync(1, 10), Times.Once);
		}

		[Fact]
		public async Task Query_GetById()
		{
			//Arrange
			var commandFaker = new ModelFaker();
			var movements = commandFaker.movements;
			var result = _mapper.Map<MovementsModel>(movements);

			var repository = _mocker.GetMock<IMovementsRepository>();

			repository.Setup(x => x.GetByIdAsync(movements.Id));

			var handler = _mocker.CreateInstance<GetByIdHandler>();
			var requestTest = new GetById { Id = movements.Id };
			var cancellationToken = new CancellationToken();

			//Act
			await handler.Handle(requestTest, cancellationToken);

			//Assert
			repository.Verify(x => x.GetByIdAsync(movements.Id), Times.Once);
		}

		[Fact]
		public async Task Query_GetAll_NoContent()
		{
			//Arrange
			var list = new List<Movements>();
			var movements = new PagesBase<Movements>();

			var repository = _mocker.GetMock<IMovementsRepository>();

			repository.Setup(x => x.GetAllAsync(1, 10)).ReturnsAsync(movements);

			var handler = _mocker.CreateInstance<GetAllHandler>();
			var requestTest = new GetAll { page = 1, itemsPerPage = 10 };
			var cancellationToken = new CancellationToken();

			//Act
			await handler.Handle(requestTest, cancellationToken);

			//Assert
			repository.Verify(x => x.GetAllAsync(1, 10), Times.Once);
		}
	}
}