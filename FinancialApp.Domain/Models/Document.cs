using FinancialApp.Domain.Models.Validations;
using FinancialApp.Shared;
using FinancialApp.Shared.Enums;

namespace FinancialApp.Domain.Models;

public class Document : EntityBase<Document>
{
    public override bool IsValid()
    {
        if(ValidationResult == null)
        {
            var validator = new DocumentValidations();
            ValidationResult = validator.Validate(this);
        }

        return ValidationResult?.IsValid != false;
    }

    public string Number { get; set; }
    public DateTimeOffset Date { get; set; }
    public TypeDocument DocumentType { get; set; }
    public Operation Operation { get; set; }
    public bool Paid { get; set; }
    public DateTimeOffset PaymentDate { get; set; }
    public string Description { get; set; }
    public decimal Total { get; set; }
    public string Observation { get; set; }
}