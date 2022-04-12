using FinacialApp.Domain.Models;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Interfaces;

public interface IMapperBuyRequest
{
	#region Mappers

	BuyRequest MapperToEntity(BuyRequestDTO buyRequestDto);

	IEnumerable<BuyRequestDTO> MapperListBuyRequest(IEnumerable<BuyRequest> buyRequest);

	BuyRequestDTO MapperToDTO(BuyRequest buyRequest);

	#endregion Mappers
}