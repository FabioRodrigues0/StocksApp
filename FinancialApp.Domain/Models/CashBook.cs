using FinancialApp.Domain.Models.Validations;
using FinancialApp.Shared;
using FinancialApp.Shared.Enums;

namespace FinancialApp.Domain.Models;

public class CashBook : EntityBase<CashBook>
{
	public override bool IsValid()
	{
		if(ValidationResult == null)
		{
			var validator = new CashBookValidations();
			ValidationResult = validator.Validate(this);
		}

		return ValidationResult?.IsValid != false;
	}

	public Origin Origin { get; set; }
	public Guid OriginId { get; set; }
	public string Description { get; set; }
	public StatusCashBook Type { get; set; }
	public decimal Valor { get; set; }
	public bool IsEdited { get; set; } = false;
}