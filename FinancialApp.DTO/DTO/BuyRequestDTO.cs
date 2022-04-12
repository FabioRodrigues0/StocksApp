using FinacialApp.Shared;

namespace FinancialApp.DTO.DTO;

public class BuyRequestDTO
{
	public Guid Id { get; set; }
	public long Code { get; set; }
	public DateTimeOffset Date { get; set; }
	public DateTimeOffset DateDelivery { get; set; }
	public Guid Client { get; set; }
	public string ClientDescription { get; set; }
	public string ClientEmail { get; set; }
	public string ClientPhoneNumber { get; set; }
	public Status Status { get; set; }
	public ICollection<BuyRequestProductDTO> ProductsList { get; set; }
	public string Address { get; set; }
	public string AddressNumber { get; set; }
	public string ZipCode { get; set; }
	public string AddressDescription { get; set; }
	public string City { get; set; }
	public string State { get; set; }
	public decimal ProductValor { get; set; }
	public decimal Descont { get; set; }
	public decimal CostValor { get; set; }
	public decimal TotalValor { get; set; }
}