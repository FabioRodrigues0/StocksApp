using System;
using System.Collections.Generic;
using Infrastructure.Shared.Enums;

namespace Stock.Application.Models
{
	public class MovementsModel
	{
		public Origin Origin { get; set; }
		public Guid OriginId { get; set; }
		public DateTimeOffset Date { get; set; }
		public Operation Type { get; set; }
		public List<ProductsMovementModel> ProductsMovements { get; set; }
	}
}