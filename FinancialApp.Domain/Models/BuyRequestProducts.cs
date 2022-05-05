using FinancialApp.Domain.Models.Validations;
using FinancialApp.Shared;
using FinancialApp.Shared.Enums;
using Newtonsoft.Json;

namespace FinancialApp.Domain.Models;

public class BuyRequestProducts : EntityBase<BuyRequestProducts>
{
	public decimal Total { get; set; }

	public override bool IsValid()
	{
		if(ValidationResult == null)
		{
			var validator = new BuyRequestProductsValidations();
			ValidationResult = validator.Validate(this);
		}

		return ValidationResult?.IsValid != false;
	}

	public virtual BuyRequest BuyRequest { get; set; }
	public Guid BuyRequestId { get; set; }

	public Guid ProductId = Guid.NewGuid();
	public string ProductDescription { get; set; }
	public ProductCategory ProductCategory { get; set; }
	public decimal Quantity { get; set; }
	public decimal Valor { get; set; }
}