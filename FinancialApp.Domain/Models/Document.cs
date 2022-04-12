using FinacialApp.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinacialApp.Domain.Models;

public class Document : BaseModel
{
	public Document()
	{
	}

	public Document(string number, TypeDocument typeDocument, Operation operation, bool isPaid, DateTimeOffset datePaidOut, string description, decimal total, string observation)
	{
		Id = Guid.NewGuid();
		Number = number;
		Date = DateTimeOffset.Now;
		TypeDocument = typeDocument;
		Operation = operation;
		this.isPaid = isPaid;
		DatePaidOut = datePaidOut;
		Description = description;
		Total = total;
		Observation = observation;
	}

	public Guid Id { get; set; }
	public string Number { get; set; }

	public DateTimeOffset Date { get; set; }
	public TypeDocument TypeDocument { get; set; }

	public Operation Operation { get; set; }
	public bool isPaid { get; set; }
	public DateTimeOffset DatePaidOut { get; set; }
	public string Description { get; set; }

	[Column(TypeName = "decimal(18,2)")]
	public decimal Total { get; set; }

	public string Observation { get; set; }
}