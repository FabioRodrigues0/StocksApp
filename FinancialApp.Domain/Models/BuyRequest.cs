using FinacialApp.Domain.Models;
using FinancialApp.Shared;

namespace FinancialApp.Domain.Models;

public class BuyRequest : BaseModel
{
	public readonly BuyRequestProducts BuyRequestProducts;

	public BuyRequest()
	{
	}

	public BuyRequest(long code,
										DateTimeOffset deliveryDate,
										Guid client,
										string clientDescription,
										string clientEmail,
										string clientPhone,
										Status status,
										string street,
										string number,
										string sector,
										string complement,
										string city,
										string state,
										decimal discount,
										List<BuyRequestProducts> products)
	{
		Id = Guid.NewGuid();
		Code = code;
		Date = DateTimeOffset.Now;
		DeliveryDate = deliveryDate;
		Client = client;
		ClientDescription = clientDescription;
		ClientEmail = clientEmail;
		ClientPhone = clientPhone;
		Status = Status.Received;
		Street = street;
		Number = number;
		Sector = sector;
		Complement = complement;
		City = city;
		State = state;
		Discount = discount;
		if(BuyRequestProducts != null) Cost = BuyRequestProducts.Total;
		Products = products.ToList();
		if(BuyRequestProducts != null) ProductValor = BuyRequestProducts.Total;
		TotalValor = ProductValor - Discount;
	}

	public Guid Id { get; set; }
	public long Code { get; set; }
	public DateTimeOffset Date { get; set; }
	public DateTimeOffset DeliveryDate { get; set; }
	public List<BuyRequestProducts> Products { get; set; }
	public Guid Client { get; set; }
	public string ClientDescription { get; set; }
	public string ClientEmail { get; set; }
	public string ClientPhone { get; set; }
	public Status Status { get; set; }
	public string Street { get; set; }
	public string Number { get; set; }
	public string Sector { get; set; }
	public string Complement { get; set; }
	public string City { get; set; }
	public string State { get; set; }
	public decimal Discount { get; set; }
	public decimal Cost { get; set; }
	public decimal ProductValor { get; set; }
	public decimal TotalValor { get; set; }
}