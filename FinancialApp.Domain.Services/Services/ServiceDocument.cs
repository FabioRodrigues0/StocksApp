using FinacialApp.Domain.Models;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Core.Services;
using FinancialApp.Shared;

namespace FinancialApp.Domain.Services.Services;

public class ServiceDocument : ServiceBase<Document>, IServiceDocument
{
	private readonly IRepositoryDocument repositoryDocument;

	public ServiceDocument(IRepositoryDocument repositoryDocument)
		: base(repositoryDocument)
	{
		this.repositoryDocument = repositoryDocument;
	}
}