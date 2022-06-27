using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Stock.Application.Map;

namespace Stock.Api.Extentions
{
	public static class AutoMapperExtention
	{
		public static void AddMapper(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(Program));
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new MovementAutomapper());
				cfg.AddProfile(new ProductsMovementAutomapper());
				cfg.AddProfile(new PagesMapper());
			});
			var mapper = config.CreateMapper();

			services.AddSingleton(mapper);
		}
	}
}