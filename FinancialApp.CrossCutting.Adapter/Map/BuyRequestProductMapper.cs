using FinacialApp.Domain.Models;
using FinancialApp.CrossCutting.Adapter.Interfaces;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Map;

public class BuyRequestProductMapper : IBuyRequestProductMapper
{
	#region methods

	public List<BuyRequestProductDto> MapProductListDto(List<BuyRequestProducts> products)
	{
		return products.Select(MapProductDto).ToList();
	}

	public List<BuyRequestProducts> MapProductList(List<BuyRequestProductDto> products)
	{
		return products.Select(MapProduct).ToList();
	}

	public BuyRequestProducts MapProduct(BuyRequestProductDto productDto)
	{
		if(productDto == null)
			return null;

		return new BuyRequestProducts()
		{
			ProductDescription = productDto.ProductDescription,
			ProductCategory = productDto.ProductCategory,
			Quantity = productDto.Quantity,
			Valor = productDto.Valor
		};
	}

	public BuyRequestProductDto MapProductDto(BuyRequestProducts productDto)
	{
		if(productDto == null)
			return null;

		return new BuyRequestProductDto()
		{
			ProductDescription = productDto.ProductDescription,
			ProductCategory = productDto.ProductCategory,
			Quantity = productDto.Quantity,
			Valor = productDto.Valor
		};
	}

	#endregion methods
}