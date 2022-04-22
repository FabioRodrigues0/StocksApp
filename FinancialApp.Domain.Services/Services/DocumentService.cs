using FinacialApp.Domain.Models;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Core.Services;
using FinancialApp.Shared;

namespace FinancialApp.Domain.Services.Services;

public class DocumentService : ServiceBase<Document>, IDocumentService
{
	private readonly IDocumentRepository _documentRepository;

	public DocumentService(IDocumentRepository documentRepository)
		: base(documentRepository)
	{
		this._documentRepository = documentRepository;
	}
}