using FinancialApp.Shared;

namespace FinancialApp.DTO.DTO;

public class CashBookDto
{
	public Origin Origin { get; set; }
	public Guid OriginId { get; set; }
	public string Description { get; set; }
	public StatusCashBook Type { get; set; }
	public decimal Valor { get; set; }
}