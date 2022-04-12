using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinacialApp.Shared;

namespace FinacialApp.Domain.Models;

public class CashBook : BaseModel
{
	public CashBook()
	{
	}

	public CashBook(Origin? origin, Guid? originId, string description, StatusCashBook type, decimal valor)
	{
		Id = Guid.NewGuid();
		Origin = origin;
		OriginId = originId;
		Description = description;
		Type = type;
		Valor = valor;
	}

	public Guid Id { get; set; }
	public Origin? Origin { get; set; }
	public Guid? OriginId { get; set; }
	public string Description { get; set; }
	public StatusCashBook Type { get; set; }

	[Column(TypeName = "decimal(18,2)")]
	public decimal Valor { get; set; }
}