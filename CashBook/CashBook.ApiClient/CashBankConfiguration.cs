using CashBook.ApiClient.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashBook.ApiClient;

public static class CashBankConfiguration
{
	public static void AddCashBankConfiguration(this IServiceCollection services, IConfiguration configuration)
	{
		services.Configure<CashBankOptions>(options =>
		{
			options.BaseAddress = configuration["CashBookUrl:BaseUrl"];
			options.CashBankPostEndPoint = configuration["CashBookUrl:EndPoint"];
		});
		services.AddHttpClient<ICashBookApiClient, CashBookApiClient>();
	}
}