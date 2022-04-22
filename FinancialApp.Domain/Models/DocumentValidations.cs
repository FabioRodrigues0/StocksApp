using FluentValidation;

namespace FinacialApp.Domain.Models;

public class DocumentValidations : AbstractValidator<Document>
{
	public DocumentValidations()
	{
	}
}