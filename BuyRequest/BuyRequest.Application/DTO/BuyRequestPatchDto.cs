using Infrastructure.Shared.Enums;

namespace BuyRequest.Application.DTO;

public class BuyRequestPatchDto
{
	public Guid Id { get; set; }
	public Status Status { get; set; }
}