using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq.AutoMock;
using Shouldly;
using Stock.Data.Repositories;
using Xunit;

namespace Stocks.UnitTest.Movement
{
	public class RepositoryMovementTest
	{
		public readonly AutoMocker _mocker;
		public RepositoryMovementTest()
		{
			_mocker = new AutoMocker();
		}

		[Fact]
		public async Task MovementsRepository_GetAll_Test()
		{
			#region Arrange
			var movements = new ModelFaker().movements;

			//Mock Instances
			var repository = _mocker.CreateInstance<MovementsRepository>();

			#endregion Arrange

			#region Act

			var taskResult = Task.Run(() => { repository.GetAllAsync(1); });

			#endregion Act

			#region Assert

			await taskResult.ShouldNotThrowAsync();

			#endregion Assert
		}

		[Fact]
		public async Task MovementsRepository_GetByIdAsync_Test()
		{
			#region Arrange
			var movements = new ModelFaker().movements;

			//Mock Instances
			var repository = _mocker.CreateInstance<MovementsRepository>();

			#endregion Arrange

			#region Act

			var taskResult = Task.Run(() => { repository.GetByIdAsync(movements.Id); });

			#endregion Act

			#region Assert

			await taskResult.ShouldNotThrowAsync();

			#endregion Assert
		}

		[Fact]
		public async Task MovementsRepository_RemoveAsync_Test()
		{
			#region Arrange
			var movements = new ModelFaker().movements;

			//Mock Instances
			var repository = _mocker.CreateInstance<MovementsRepository>();

			#endregion Arrange

			#region Act

			var taskResult = Task.Run(() => { repository.RemoveAsync(movements.Id); });

			#endregion Act

			#region Assert

			await taskResult.ShouldNotThrowAsync();

			#endregion Assert
		}

		[Fact]
		public async Task MovementsRepository_AddAsync_Test()
		{
			#region Arrange
			var movements = new ModelFaker().movements;

			//Mock Instances
			var repository = _mocker.CreateInstance<MovementsRepository>();

			#endregion Arrange

			#region Act

			var taskResult = Task.Run(() => { repository.AddAsync(movements); });

			#endregion Act

			#region Assert

			await taskResult.ShouldNotThrowAsync();

			#endregion Assert
		}
	}
}
