using Document.Application.Map;

namespace Document.Api.Extentions;

public static class AutoMapperExtention
{
	public static void AddMapper(this IServiceCollection services)
	{
		services.AddAutoMapper(typeof(Program));
		var config = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile(new DocumentAutoMapper());
			cfg.AddProfile(new PagesDocumentMapper());
			cfg.AddProfile(new CashBookConverterAutoMapper());
		});
		var mapper = config.CreateMapper();

		services.AddSingleton(mapper);
	}
}