using FinancialApp.DTO.DTO;

namespace FinancialApp.Application.Interface;

public interface IApplicationServiceCashBook
{
	void Add(CashBookDTO obj);

	CashBookDTO GetById(int id);

	IEnumerable<CashBookDTO> GetAll();

	void Update(CashBookDTO obj);

	void Remove(CashBookDTO obj);

	void Dispose();
}