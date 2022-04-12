using FinacialApp.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinacialApp.Domain.Models;

public class BuyRequest : BaseModel
{
	public BuyRequest()
	{
	}

	public BuyRequest(long code,
										DateTimeOffset dateDelivery,
										Guid client,
										string clientDescription,
										string clientEmail,
										string clientPhoneNumber,
										Status status,
										string address,
										string addressNumber,
										string zipCode,
										string addressDescription,
										string city,
										string state,
										decimal productValor,
										decimal descont,
										decimal costValor,
										ICollection<BuyRequestProducts> productsList)
	{
		Id = Guid.NewGuid();
		Code = code;
		Date = DateTimeOffset.Now;
		DateDelivery = dateDelivery;
		Client = client;
		ClientDescription = clientDescription;
		ClientEmail = clientEmail;
		ClientPhoneNumber = clientPhoneNumber;
		Status = status;
		Address = address;
		AddressNumber = addressNumber;
		ZipCode = zipCode;
		AddressDescription = addressDescription;
		City = city;
		State = state;
		ProductValor = productValor;
		Descont = descont;
		CostValor = costValor;
		ProductsList = productsList;
		TotalValor = ProductValor - Descont;
	}

	public Guid Id { get; set; }
	public long Code { get; set; }
	public DateTimeOffset Date { get; set; }
	public DateTimeOffset DateDelivery { get; set; }
	public Guid Client { get; set; }
	public string ClientDescription { get; set; }
	public string ClientEmail { get; set; }
	public string ClientPhoneNumber { get; set; }
	public ICollection<BuyRequestProducts> ProductsList { get; set; }
	public Status Status { get; set; }
	public string Address { get; set; }
	public string AddressNumber { get; set; }
	public string ZipCode { get; set; }
	public string AddressDescription { get; set; }
	public string City { get; set; }
	public string State { get; set; }

	[Column(TypeName = "decimal(18,2)")]
	public decimal ProductValor { get; set; }

	[Column(TypeName = "decimal(18,2)")]
	public decimal Descont { get; set; }

	[Column(TypeName = "decimal(18,2)")]
	public decimal CostValor { get; set; }

	[Column(TypeName = "decimal(18,2)")]
	public decimal TotalValor { get; set; }
}