namespace BuyRequest.Application.DTO;

public class PagesBuyRequestDto
{
	public List<BuyRequestDto> Models { get; set; }
	public int CurrentPage { get; set; }
	public int Pages { get; set; }
}