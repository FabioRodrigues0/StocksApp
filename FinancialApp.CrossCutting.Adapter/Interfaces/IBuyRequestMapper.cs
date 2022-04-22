using FinacialApp.Domain.Models;
using FinancialApp.Domain.Models;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Interfaces;

public interface IBuyRequestMapper
{
	#region Mappers

	BuyRequest MapperToEntity(BuyRequestDto buyRequestDto);

	PagesBuyRequestDto MapperListBuyRequest(List<BuyRequest> buyRequest, int page);

	BuyRequestDto MapperToDTO(BuyRequest buyRequest);

	#endregion Mappers
}