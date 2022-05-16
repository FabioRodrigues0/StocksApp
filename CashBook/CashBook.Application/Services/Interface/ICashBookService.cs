using CashBook.Application.DTO;
using CashBook.Domain.Models;
using Infrastructure.Shared.Interfaces;

namespace CashBook.Application.Services.Interface;

public interface ICashBookService : IServiceBase<CashBooks>
{
	Task<List<CashBooks>> GetByOriginId(Guid id);

	Task<(List<CashBooks> list, int totalPages, int page)> GetAll(int page);
}