namespace Document.Application.DTO;

public class PagesDocumentDto
{
	public List<DocumentDto> Models { get; set; }
	public int CurrentPage { get; set; }
	public int Pages { get; set; }
}