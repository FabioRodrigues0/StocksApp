using Infrastructure.Shared.Enums;

namespace CashBook.Application.DTO;

public class CashBookUpdateDto
{
	public Guid Id { get; set; }
	public Origin Origin { get; set; }
	public Guid OriginId { get; set; }
	public string Description { get; set; }
	public StatusCashBook Type { get; set; }
	public decimal Valor { get; set; }
}