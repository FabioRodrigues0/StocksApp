using AutoMapper;
using Infrastructure.Shared.Enums;
using Infrastructure.Shared.Services;
using Infrastructure.Shared.Services.Interface;
using Moq;
using Moq.AutoMock;
using Stock.Application.Application.Handlers.Movement;
using Stock.Application.Commands;
using Stock.Application.DTO;
using Stock.Application.Map;
using Stock.Data.Repositories.Interfaces;
using Stock.Domain.Models;
using Xunit;

namespace Stocks.UnitTest.Movement
{
	public class CommandMovementTest
	{
		public readonly AutoMocker _mocker;
		private static IMapper _mapper;
		bool resultBool;

		public CommandMovementTest()
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
		public async Task Command_Post()
		{
			//Arrange
			var commandFaker = new ModelFaker();
			var movements = commandFaker.movements;
			var result = _mapper.Map<MovementsDto>(movements);

			var repository = _mocker.GetMock<IMovementsRepository>();
			var mapperMock = _mocker.GetMock<IMapper>();

			mapperMock.Setup(x => x.Map<Movements>(result)).Returns(movements);
			repository.Setup(x => x.AddAsync(movements));

			var handler = _mocker.CreateInstance<PostHandler>();
			var requestTest = new Post { Movements = result };
			var cancellationToken = new CancellationToken();

			//Act
			await handler.Handle(requestTest, cancellationToken);

			//Assert
			repository.Verify(x => x.AddAsync(It.IsAny<Movements>()), Times.Once);
		}

		[Fact]
		public async Task Command_Post_FailValidation()
		{
			//Arrange
			var commandFaker = new ModelFaker();
			var movements = commandFaker.movementsFailValidation;
			var result = _mapper.Map<MovementsDto>(movements);

			var repository = _mocker.GetMock<IMovementsRepository>();
			var serviceContext = _mocker.GetMock<IServiceContext>();
			var validationsBase = _mocker.GetMock<ValidationsBase<Movements>>();

			var handler = _mocker.CreateInstance<PostHandler>();

			//validationsBase.Setup(x => x.ValidateEntity(movements));
			serviceContext.Setup(x => x.HasNotification());
			repository.Setup(x => x.AddAsync(movements));

			
			var requestTest = new Post { Movements = result };
			var cancellationToken = new CancellationToken();

			//Act
			await handler.Handle(requestTest, cancellationToken);

			//Assert
			validationsBase.Verify(x => x.IsValidOperation != true);
		}

		[Fact]
		public async Task Command_Delete()
		{
			//Arrange
			var commandFaker = new ModelFaker();
			var movements = commandFaker.movements;
			var result = _mapper.Map<MovementsDto>(movements);

			var repository = _mocker.GetMock<IMovementsRepository>();

			repository.Setup(x => x.RemoveAsync(movements.Id));

			var handler = _mocker.CreateInstance<DeleteHandler>();
			var requestTest = new Delete { Id = movements.Id };
			var cancellationToken = new CancellationToken();

			//Act
			await handler.Handle(requestTest, cancellationToken);

			//Assert
			repository.Verify(x => x.RemoveAsync(movements.Id), Times.Once);
		}
	}
}