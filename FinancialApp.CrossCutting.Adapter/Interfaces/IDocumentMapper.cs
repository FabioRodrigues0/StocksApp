using FinacialApp.Domain.Models;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Interfaces;

public interface IDocumentMapper
{
	#region Mappers

	Document MapperToEntity(DocumentDto documentDto);

	PagesDocumentDto MapperListDocument(List<Document> documents, int page);

	DocumentDto MapperToDTO(Document document);

	#endregion Mappers
}