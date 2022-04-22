using FinancialApp.Shared;
using FluentValidation;

namespace FinacialApp.Domain.Models;

public class CashBookValidations : AbstractValidator<CashBook>
{
	public CashBookValidations()
	{
		RuleFor(x => x.Valor).GreaterThanOrEqualTo(0).When(x => x.Type == StatusCashBook.Receivement);
		RuleFor(x => x.Valor).LessThanOrEqualTo(0).When(x => x.Type == StatusCashBook.Payment);
	}
}