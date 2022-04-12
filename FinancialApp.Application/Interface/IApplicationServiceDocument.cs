using FinancialApp.DTO.DTO;

namespace FinancialApp.Application.Interface;

public interface IApplicationServiceDocument
{
	void Add(DocumentDTO obj);

	DocumentDTO GetById(int id);

	IEnumerable<DocumentDTO> GetAll();

	void Update(DocumentDTO obj);

	void Remove(DocumentDTO obj);

	void Dispose();
}