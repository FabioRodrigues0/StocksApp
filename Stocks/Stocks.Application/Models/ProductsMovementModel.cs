using System;
using Infrastructure.Shared.Enums;

namespace Stock.Application.Models
{
	public class ProductsMovementModel
	{
		public Guid ProductId { get; set; }
		public string ProductDescription { get; set; }
		public ProductCategory ProductCategory { get; set; }
		public decimal Quantity { get; set; }
		public decimal ValorPerUnit { get; set; }
		public Guid StorageId { get; set; }
		public string StorageDescription { get; set; }
	}
}