using FinancialApp.Domain.Models;
using FinancialApp.Shared;
using FluentValidation;

namespace FinacialApp.Domain.Models;

public class BuyRequestValidations : AbstractValidator<BuyRequest>
{
	public BuyRequestValidations()
	{
		RuleFor(x => x.Id).NotNull();
		RuleFor(x => x.Code).NotNull();
		RuleFor(x => x.Date).NotNull();
		RuleFor(x => x.DeliveryDate).NotNull().When(x => x.Status == Status.Finished);
		RuleForEach(x => x.Products)
			.SetValidator(new BuyRequestProductsValidations());
		RuleFor(x => x.Products).Must(x => x.Any());
		RuleForEach(x => x.Products).Must(IsValidCategory);
		RuleFor(x => x.Client).NotNull();
		RuleFor(x => x.ClientDescription).NotNull();
		RuleFor(x => x.ClientEmail)
			.NotNull()
			.EmailAddress();
		RuleFor(x => x.ClientPhone).MinimumLength(9);
		RuleFor(x => x.Status)
			.IsInEnum()
			.Must(x => x != Status.AwaitingDownload).When(x => x.Products.Any(x => x.ProductCategory == ProductCategory.Physical))
			.Must(x => x != Status.AwaitingDelivery).When(x => x.Products.Any(x => x.ProductCategory == ProductCategory.Digital))
			.Must(x => x == Status.Finished).When(x => x.Status == Status.Finished);
		RuleFor(x => x.ProductValor).NotNull();
		RuleFor(x => x.Discount).GreaterThanOrEqualTo(0);
		RuleFor(x => x.Cost).NotNull();
		RuleFor(x => x.TotalValor).ScalePrecision(2, 4);
	}

	private bool IsValidCategory(BuyRequest p, BuyRequestProducts pq)
	{
		var result = p.Products.Count(y => y.ProductCategory == ProductCategory.Digital);
		var result2 = p.Products.Count(y => y.ProductCategory == ProductCategory.Physical);
		var result3 = p.Products.Count();
		if((result == result3 || result2 == 0) || (result2 == result3 || result == 0))
			return true;
		return false;
	}
}