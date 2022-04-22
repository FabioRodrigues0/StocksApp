using FinancialApp.Application.Interface;
using FinancialApp.CrossCutting.Adapter.Interfaces;
using FinancialApp.Domain.Core.Services;
using FinancialApp.DTO.DTO;

namespace FinancialApp.Application.Service;

public class ApplicationDocumentService : IApplicationDocumentService
{
	private readonly IDocumentService _documentService;
	private readonly IDocumentMapper _documentMapper;

	public ApplicationDocumentService(IDocumentService documentService,
																		IDocumentMapper documentMapper)
	{
		_documentService = documentService;
		_documentMapper = documentMapper;
	}

	public void Add(DocumentDto obj)
	{
		var documents = _documentMapper.MapperToEntity(obj);
		_documentService.Add(documents);
	}

	public DocumentDto GetById(Guid id)
	{
		var documents = _documentService.GetById(id);
		var documentDto = _documentMapper.MapperToDTO(documents);

		return documentDto;
	}

	public PagesDocumentDto GetByPage(int page)
	{
		var documents = _documentService.GetByPage(page);
		var documentDto = _documentMapper.MapperListDocument(documents, page);

		return documentDto;
	}

	public PagesDocumentDto GetAll()
	{
		var documents = _documentService.GetAll();
		var documentDto = _documentMapper.MapperListDocument(documents, 1);

		return documentDto;
	}

	public void Update(DocumentDto obj)
	{
		var document = _documentMapper.MapperToEntity(obj);
		_documentService.Update(document);
	}

	public void Remove(DocumentDto obj)
	{
		var document = _documentMapper.MapperToEntity(obj);
		_documentService.Remove(document);
	}
}