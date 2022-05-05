namespace FinancialApp.DTO.DTO;

public class PagesCashBookDto
{
    public List<CashBookDto> Models { get; set; }
    public int CurrentPage { get; set; }
    public int Pages { get; set; }
    public decimal Total { get; set; }
}