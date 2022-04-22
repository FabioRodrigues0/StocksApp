using FinacialApp.Domain.Models;
using FinancialApp.CrossCutting.Adapter.Interfaces;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Map;

public class DocumentMapper : IDocumentMapper
{
	#region properties

	private readonly List<DocumentDto> _documentDtos = new List<DocumentDto>();
	private readonly PagesDocumentDto _pagesDocumentDto = new PagesDocumentDto();

	#endregion properties

	#region methods

	public Document MapperToEntity(DocumentDto documentDto)
	{
		Document document = new Document()
		{
			Number = documentDto.Number,
			Date = documentDto.Date,
			TypeDocument = documentDto.DocumentType,
			Operation = documentDto.Operation,
			isPaid = documentDto.Paid,
			DatePaidOut = documentDto.PaymentDate,
			Description = documentDto.Description,
			Total = documentDto.Total,
			Observation = documentDto.Observation
		};
		return document;
	}

	public PagesDocumentDto MapperListDocument(List<Document> documents, int page)
	{
		var pageResults = 3f;
		var pageCount = Math.Ceiling(documents.Count() / pageResults);

		foreach(var d in documents)
		{
			DocumentDto documentsDto = new DocumentDto
			{
				Number = d.Number,
				Date = d.Date,
				DocumentType = d.TypeDocument,
				Operation = d.Operation,
				Paid = d.isPaid,
				PaymentDate = d.DatePaidOut,
				Description = d.Description,
				Total = d.Total,
				Observation = d.Observation
			};
			_documentDtos.Add(documentsDto);
		}

		_pagesDocumentDto.Models = _documentDtos;
		_pagesDocumentDto.CurrentPage = page;
		_pagesDocumentDto.Pages = (int)pageCount;

		return _pagesDocumentDto;
	}

	public DocumentDto MapperToDTO(Document document)
	{
		DocumentDto documentsDto = new DocumentDto
		{
			Number = document.Number,
			Date = document.Date,
			DocumentType = document.TypeDocument,
			Operation = document.Operation,
			Paid = document.isPaid,
			PaymentDate = document.DatePaidOut,
			Description = document.Description,
			Total = document.Total,
			Observation = document.Observation
		};
		return documentsDto;
	}

	#endregion methods
}