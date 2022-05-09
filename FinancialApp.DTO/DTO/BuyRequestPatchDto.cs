using FinancialApp.Shared.Enums;

namespace FinancialApp.DTO.DTO;

public class BuyRequestPatchDto
{
	public Guid Id { get; set; }
	public Status Status { get; set; }
}