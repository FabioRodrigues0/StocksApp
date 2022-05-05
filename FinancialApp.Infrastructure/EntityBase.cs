using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FinancialApp.Shared;

public abstract class EntityBase<TEntity>
{
	public Guid Id { get; set; }

	#region Validation

	[NotMapped]
	[JsonIgnore]
	public ValidationResult ValidationResult { get; protected set; }

	public abstract bool IsValid();

	#endregion Validation
}