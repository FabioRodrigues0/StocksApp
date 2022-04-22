using FinancialApp.DTO.DTO;

namespace FinancialApp.Application.Interface;

public interface IApplicationDocumentService
{
	void Add(DocumentDto obj);

	DocumentDto GetById(Guid id);

	PagesDocumentDto GetByPage(int page);

	PagesDocumentDto GetAll();

	void Update(DocumentDto obj);

	void Remove(DocumentDto obj);
}