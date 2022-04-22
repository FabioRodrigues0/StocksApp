using FinancialApp.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using FinancialApp.Domain.Models;

namespace FinacialApp.Domain.Models;

public class BuyRequestProducts : BaseModel
{
	public Guid Id { get; set; }
	public Guid BuyRequestId { get; set; }
	public virtual BuyRequest BuyRequest { get; set; }
	public Guid ProductId { get; set; }
	public string ProductDescription { get; set; }
	public ProductCategory ProductCategory { get; set; }
	public decimal Quantity { get; set; }
	public decimal Valor { get; set; }
	public decimal Total;

	public BuyRequestProducts()
	{
		Total = Quantity * Valor;
	}
}