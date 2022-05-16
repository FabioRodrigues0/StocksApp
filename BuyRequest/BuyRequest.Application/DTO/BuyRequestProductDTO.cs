using Infrastructure.Shared.Enums;

namespace BuyRequest.Application.DTO;

public class BuyRequestProductDto
{
	public string ProductDescription { get; set; }
	public ProductCategory ProductCategory { get; set; }
	public decimal Quantity { get; set; }
	public decimal Valor { get; set; }
}