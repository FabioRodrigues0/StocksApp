using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinacialApp.Shared;

namespace FinacialApp.Domain.Models;

public class BuyRequestProducts : BaseModel
{
	public BuyRequestProducts(Guid buyRequestId, Guid productId, string productDescription, ProductCategory productCategory, decimal quantity, decimal valor, decimal total)
	{
		Id = Guid.NewGuid();
		BuyRequestId = buyRequestId;
		ProductId = productId;
		ProductDescription = productDescription;
		ProductCategory = productCategory;
		Quantity = quantity;
		Valor = valor;
		Total = total;
	}

	private Guid Id { get; set; }

	[ForeignKey("FK_BuyRequestProducts_BuyRequestId_BuyRequest_Id")]
	public Guid BuyRequestId { get; set; }

	public Guid ProductId { get; set; }
	public string ProductDescription { get; set; }
	public ProductCategory ProductCategory { get; set; }

	[Column(TypeName = "decimal(18,2)")]
	public decimal Quantity { get; set; }

	[Column(TypeName = "decimal(18,2)")]
	public decimal Valor { get; set; }

	[Column(TypeName = "decimal(18,2)")]
	public decimal Total { get; set; }
}