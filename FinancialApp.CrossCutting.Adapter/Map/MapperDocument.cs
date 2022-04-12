using FinacialApp.Domain.Models;
using FinancialApp.CrossCutting.Adapter.Interfaces;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Map;

public class MapperDocument : IMapperDocument
{
	#region properties

	private readonly List<DocumentDTO> _documentDtOs = new List<DocumentDTO>();

	#endregion properties

	#region methods

	public Document MapperToEntity(DocumentDTO documentDto)
	{
		Document document = new Document()
		{
			Id = documentDto.Id,
			Number = documentDto.Number,
			Date = documentDto.Date,
			TypeDocument = documentDto.TypeDocument,
			Operation = documentDto.Operation,
			isPaid = documentDto.isPaid,
			DatePaidOut = documentDto.DatePaidOut,
			Description = documentDto.Description,
			Total = documentDto.Total,
			Observation = documentDto.Observation
		};
		return document;
	}

	public IEnumerable<DocumentDTO> MapperListDocument(IEnumerable<Document> documents)
	{
		foreach(var d in documents)
		{
			DocumentDTO documentsDto = new DocumentDTO
			{
				Id = d.Id,
				Number = d.Number,
				Date = d.Date,
				TypeDocument = d.TypeDocument,
				Operation = d.Operation,
				isPaid = d.isPaid,
				DatePaidOut = d.DatePaidOut,
				Description = d.Description,
				Total = d.Total,
				Observation = d.Observation
			};
			_documentDtOs.Add(documentsDto);
		}
		return _documentDtOs;
	}

	public DocumentDTO MapperToDTO(Document document)
	{
		DocumentDTO documentsDto = new DocumentDTO
		{
			Id = document.Id,
			Number = document.Number,
			Date = document.Date,
			TypeDocument = document.TypeDocument,
			Operation = document.Operation,
			isPaid = document.isPaid,
			DatePaidOut = document.DatePaidOut,
			Description = document.Description,
			Total = document.Total,
			Observation = document.Observation
		};
		return documentsDto;
	}

	#endregion methods
}