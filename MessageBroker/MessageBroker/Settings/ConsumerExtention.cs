using Infrastructure.Shared.Messaging.Settings;
using Infrastructure.Shared.Messaging.Settings.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBroker.Settings
{
	public static class ConsumerExtention
	{
		public static void AddConsumer(this IServiceCollection services)
		{
			services.AddHostedService<Consumer>();
			services.AddScoped<RabbitMqOptions, RabbitMqOptions>();
			services.AddSingleton<IRabbitMQConnectionFactory, RabbitMQConnection>();
		}
	}
}