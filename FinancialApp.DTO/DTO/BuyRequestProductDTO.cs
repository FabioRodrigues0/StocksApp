using FinacialApp.Shared;

namespace FinancialApp.DTO.DTO;

public class BuyRequestProductDTO
{
	private Guid Id { get; set; }
	public Guid BuyRequestId { get; set; }
	public Guid ProductId { get; set; }
	public string ProductDescription { get; set; }
	public ProductCategory ProductCategory { get; set; }
	public decimal Quantity { get; set; }
	public decimal Valor { get; set; }
	public decimal Total { get; set; }
}