using Newtonsoft.Json;
using Shouldly;
using Stock.Application.DTO;
using Xunit;

namespace MessagerBroker.UnitTest
{
	public class MessageBrokerTest : RabbitInstances
	{
		[Fact]
		public async Task RabbitMq_ReceivedFromRabbit_Test()
		{
			#region Arrange

			//Mock Instances
			var consumer = CreateConsumerInstance();

			#endregion Arrange

			#region Act

			var taskResult = Task.Run(() => { consumer.ReceivedFromRabbit(); });

			#endregion Act

			#region Assert

			await taskResult.ShouldNotThrowAsync();

			#endregion Assert
		}

		[Fact]
		public async Task RabbitMq_SendToApplication_Test()
		{
			#region Arrange
			var movements = new ModelFaker().movementsDto;
			var message = JsonConvert.SerializeObject(movements);

			//Mock Instances
			var consumer = CreateConsumerInstance();

			#endregion Arrange

			#region Act

			var taskResult = Task.Run(() => { consumer.SendToApplication(message); });

			#endregion Act

			#region Assert

			await taskResult.ShouldNotThrowAsync();

			#endregion Assert
		}
	}
}
