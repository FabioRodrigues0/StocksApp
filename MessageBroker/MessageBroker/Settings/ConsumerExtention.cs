using Infrastructure.Shared.Messaging.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBroker.Settings
{
	public static class ConsumerExtention
	{
		public static void AddConsumer(this IServiceCollection services)
		{
			services.AddHostedService<Consumer>();
			services.AddScoped<RabbitMqOptions, RabbitMqOptions>();
		}
	}
}