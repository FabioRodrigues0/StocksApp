using FinancialApp.DTO.DTO;

namespace FinancialApp.Application.Interface;

public interface IApplicationServiceBuyRequest
{
	void Add(BuyRequestDTO obj);

	BuyRequestDTO GetById(int id);

	IEnumerable<BuyRequestDTO> GetAll();

	void Update(BuyRequestDTO obj);

	void Remove(BuyRequestDTO obj);

	void Dispose();
}