using FluentValidation;
using Infrastructure.Shared.Enums;

namespace Stock.Domain.Models.Validations
{
	public class MovementsValidations : AbstractValidator<Movements>
	{
		public MovementsValidations()
		{
			RuleFor(x => x.Id).NotNull().WithMessage("Id can't be null");
			RuleFor(x => x.Origin)
				.Must(IsValidOrigin).WithMessage("Origin must be Purchase Order(1)")
				.IsInEnum();
			RuleFor(x => x.Date).NotNull().WithMessage("Date can't be null");
			RuleFor(x => x.Type).NotNull().WithMessage("Type can't be null");
			RuleFor(x => x.ProductsMovements).NotNull().WithMessage("Products can't be null");
			RuleForEach(x => x.ProductsMovements)
				.SetValidator(new ProductsMovementValidations());
			
		}

		private bool IsValidOrigin(Origin origin)
		{
			if (origin == Origin.BuyRequest)
				return true;
			return false;
		}
	}
}