using FinacialApp.Data;
using FinacialApp.Domain.Models;
using FinancialApp.Domain.Core.Repositories;

namespace FinancialApp.Data;

public class RepositoryDocument : RepositoryBase<Document>, IRepositoryDocument
{
	private readonly DataContext _dataContext;

	public RepositoryDocument(DataContext dataContext)
		: base(dataContext)
	{
		_dataContext = dataContext;
	}
}