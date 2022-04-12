using FinacialApp.Shared;

namespace FinancialApp.DTO.DTO;

public class DocumentDTO
{
	public Guid Id { get; set; }
	public string Number { get; set; }
	public DateTimeOffset Date { get; set; }
	public TypeDocument TypeDocument { get; set; }
	public Operation Operation { get; set; }
	public bool isPaid { get; set; }
	public DateTimeOffset DatePaidOut { get; set; }
	public string Description { get; set; }
	public decimal Total { get; set; }
	public string Observation { get; set; }
}