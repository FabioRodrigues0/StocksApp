using FinacialApp.Data;
using FinacialApp.Domain.Models;
using FinancialApp.Domain.Core.Repositories;

namespace FinancialApp.Repository.Repository;

public class RepositoryDocument : RepositoryBase<Document>, IRepositoryDocument
{
	private readonly DataContext _context;

	public RepositoryDocument(DataContext context) : base(context)
	{
		_context = context;
	}
}