using FluentValidation;

namespace Stock.Domain.Models.Validations
{
	public class ProductsMovementValidations : AbstractValidator<ProductsMovement>
	{
		public ProductsMovementValidations()
		{
			RuleFor(x => x.Id).NotNull().WithMessage("Id can't be null");
			RuleFor(x => x.ProductId).NotNull().WithMessage("ProductId can't be null");
			RuleFor(x => x.ProductDescription).NotNull().WithMessage("Product Description can't be null");
			RuleFor(x => x.ProductCategory)
				.NotNull().WithMessage("Product Category can't be null")
				.IsInEnum();
			RuleFor(x => x.Quantity).NotNull().WithMessage("Quantity can't be null");
			RuleFor(x => x.ValorPerUnit).NotNull().WithMessage("Valor Per Unit can't be null");
			RuleFor(x => x.StorageId).NotNull().WithMessage("StorageId can't be null");
			RuleFor(x => x.StorageDescription).NotNull().WithMessage("Storage Description can't be null");
		}
	}
}