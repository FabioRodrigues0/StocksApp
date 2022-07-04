using System;
using System.Threading.Tasks;
using Infrastructure.Shared.Enums;
using Infrastructure.Shared.Entities;
using Stock.Domain.Entities.Validations;

namespace Stock.Domain.Entities
{
	public class ProductsMovement : EntityBase<ProductsMovement>
	{
		public override async Task<bool> IsValid()
		{
			if (ValidationResult == null)
			{
				var validator = new ProductsMovementValidations();
				ValidationResult = validator.Validate(this);
			}
			return ValidationResult?.IsValid != false;
		}

		public virtual Movements Movements { get; set; }
		public Guid MovementsId { get; set; }
		public Guid ProductId { get; set; }
		public string ProductDescription { get; set; }
		public ProductCategory ProductCategory { get; set; }
		public decimal Quantity { get; set; }
		public decimal ValorPerUnit { get; set; }
		public Guid StorageId { get; set; }
		public string StorageDescription { get; set; }
	}
}