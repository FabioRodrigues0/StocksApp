using Document.Application.DTO;
using Document.Domain.Models;

namespace Document.Application.Application.Interface;

public interface IApplicationDocumentService
{
	Task<Documents> Add(DocumentDto obj);

	Task<DocumentDto> GetById(Guid id);

	Task<PagesDocumentDto> GetAll(int page);

	Task<Documents> Update(DocumentUpdateDto obj);

	Task<Documents> Patch(DocumentPatchDto obj);

	Task<bool> Remove(Guid id);
}