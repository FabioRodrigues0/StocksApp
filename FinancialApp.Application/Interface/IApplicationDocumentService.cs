using FinancialApp.Domain.Models;
using FinancialApp.DTO.DTO;

namespace FinancialApp.Application.Interface;

public interface IApplicationDocumentService
{
	Task<Document> Add(DocumentDto obj);

	Task<DocumentDto> GetById(Guid id);

	Task<PagesDocumentDto> GetAll(int page);

	Task<Document> Update(DocumentUpdateDto obj);

	Task<Document> Patch(DocumentPatchDto obj);

	Task<Document> Remove(Guid id);
}