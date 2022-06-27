using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Shared.Enums;
using Infrastructure.Shared.Models;
using Stock.Domain.Models.Validations;

namespace Stock.Domain.Models
{
	public class Movements : EntityBase<Movements>
	{
		public override async Task<bool> IsValid()
		{
			if (ValidationResult == null)
			{
				var validator = new MovementsValidations();
				ValidationResult = validator.Validate(this);
			}
			return ValidationResult?.IsValid != false;
		}

		public Origin Origin { get; set; }
		public Guid OriginId { get; set; }
		public DateTimeOffset Date { get; set; }
		public Operation Type { get; set; }
		public List<ProductsMovement> ProductsMovements { get; set; }
	}
}