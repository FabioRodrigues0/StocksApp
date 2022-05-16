using Document.Service.Interface;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Models;
using FinancialApp.Shared;
using FinancialApp.Shared.Interfaces;

namespace Document.Service;

public class DocumentService : ServiceBase<Document>, IDocumentService
{
	private readonly IDocumentRepository _documentRepository;

	public DocumentService(
		IServiceContext serviceContext,
		IDocumentRepository documentRepository)
		: base(documentRepository, serviceContext)
	{
		_documentRepository = documentRepository;
	}

	public override async Task<Document> Add(Document model)
	{
		ValidateEntity(model);
		//AddNotification("Erro de negocio");
		if (!IsValidOperation)
			return null;

		return await _documentRepository.Add(model);
	}

	public override async Task<Document> Update(Document model)
	{
		ValidateEntity(model);
		//AddNotification("Erro de negocio");
		if (!IsValidOperation)
			return null;

		return await _documentRepository.Update(model);
	}

	public override async Task<Document> Patch(Document model)
	{
		return await _documentRepository.Patch(model);
	}
}