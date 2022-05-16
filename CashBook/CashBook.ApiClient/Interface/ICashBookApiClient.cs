using CashBook.Application.DTO;
using Infrastructure.Shared;

namespace CashBook.ApiClient.Interface;

public interface ICashBookApiClient
{
	Task PostAsync(CashBookDto obj);
}