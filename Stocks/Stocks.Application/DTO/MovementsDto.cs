using System;
using System.Collections.Generic;
using Infrastructure.Shared.Enums;

namespace Stock.Application.DTO
{
	public class MovementsDto
	{
		public Origin Origin { get; set; }
		public Guid OriginId { get; set; }
		public DateTimeOffset Date { get; set; }
		public Operation Type { get; set; }
		public List<ProductsMovementDto> ProductsMovements { get; set; }
	}
}