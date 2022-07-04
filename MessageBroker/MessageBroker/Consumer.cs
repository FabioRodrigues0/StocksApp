using Infrastructure.Shared.Messaging.Listener;
using Infrastructure.Shared.Messaging.Settings;
using Infrastructure.Shared.Messaging.Settings.Interface;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stock.Application.Commands;
using Stock.Application.Models;

namespace MessageBroker
{
	public class Consumer : RabbitMqListener
	{
		private readonly IServiceProvider _serviceProvider;
		private readonly ILogger _logger;

		public Consumer(
			IServiceProvider services,
			ILogger<Consumer> logger,
			IOptions<RabbitMqOptions> options,
			IRabbitMQConnectionFactory factory) : base(logger, options, factory)
		{
			_serviceProvider = services;
			_logger = logger;
		}

		public override async Task<bool> SendToApplication(string message)
		{
			var taskMessage = JToken.Parse(message);
			if (taskMessage == null)
			{
				// When false is returned, the message is rejected directly, indicating that it cannot be processed
				return false;
			}
			try
			{
				_logger.LogInformation(" - Received :'{0}'", message);
				var model = JsonConvert.DeserializeObject<MovementsModel>(message);
				_logger.LogInformation(" - Send to CashBook {obj}", message);
				using var scope = _serviceProvider.CreateScope();
				var _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
				await _mediator.Send(new Post { Movements = model });
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogInformation($"Process fail,error:{ex.Message},stackTrace:{ex.StackTrace},message:{message}");
				_logger.LogError(-1, ex, "Process fail");
				return false;
			}
		}
	}
}