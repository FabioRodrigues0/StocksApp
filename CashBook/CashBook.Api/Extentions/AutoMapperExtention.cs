using AutoMapper;
using CashBook.Application.Map;

namespace CashBook.Api.Extentions;

public static class AutoMapperExtention
{
	public static void AddMapper(this IServiceCollection services)
	{
		services.AddAutoMapper(typeof(Program));
		var config = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile(new CashBookAutoMapper());
			cfg.AddProfile(new PagesCashBookMapper());
		});
		var mapper = config.CreateMapper();

		services.AddSingleton(mapper);
	}
}