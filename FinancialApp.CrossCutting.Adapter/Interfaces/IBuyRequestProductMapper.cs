using FinacialApp.Domain.Models;
using FinancialApp.Domain.Models;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Interfaces;

public interface IBuyRequestProductMapper
{
	#region Mappers

	List<BuyRequestProductDto> MapProductListDto(List<BuyRequestProducts> products);

	List<BuyRequestProducts> MapProductList(List<BuyRequestProductDto> products);

	BuyRequestProducts MapProduct(BuyRequestProductDto productDto);

	BuyRequestProductDto MapProductDto(BuyRequestProducts productDto);

	#endregion Mappers
}