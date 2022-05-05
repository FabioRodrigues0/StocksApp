using FinancialApp.Shared;
using FinancialApp.Shared.Enums;

namespace FinancialApp.DTO.DTO;

public class DocumentPatchDto
{
    public Guid Id { get; set; }
    public bool Paid { get; set; }
}