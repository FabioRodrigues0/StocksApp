using System.Net.Http.Json;
using CashBook.ApiClient;
using CashBook.ApiClient.Interface;
using CashBook.Application.DTO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CashBook.ApiClient;

public class CashBookApiClient : ICashBookApiClient
{
	private readonly HttpClient _http;
	private readonly CashBankOptions _options;
	private readonly ILogger<CashBookApiClient> _logger;

	public CashBookApiClient(
		IOptions<CashBankOptions> options,
		ILogger<CashBookApiClient> logger,
		HttpClient http)
	{
		_logger = logger;
		_http = http;
		_options = options.Value;
	}

	public async Task PostAsync(CashBookDto obj)
	{
		_logger.LogInformation("Send to CashBook to Add {obj}", obj);
		await _http.PostAsJsonAsync($"{_options.GetCashBankEndPoint()}", obj);
	}
}