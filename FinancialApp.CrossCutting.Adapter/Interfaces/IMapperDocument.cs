using FinacialApp.Domain.Models;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Interfaces;

public interface IMapperDocument
{
	#region Mappers

	Document MapperToEntity(DocumentDTO documentDto);

	IEnumerable<DocumentDTO> MapperListDocument(IEnumerable<Document> documents);

	DocumentDTO MapperToDTO(Document document);

	#endregion Mappers
}