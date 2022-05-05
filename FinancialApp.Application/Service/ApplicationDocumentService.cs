using AutoMapper;
using FinancialApp.Application.Interface;
using FinancialApp.Domain.Core.Services;
using FinancialApp.Domain.Models;
using FinancialApp.DTO.DTO;

namespace FinancialApp.Application.Service;

public class ApplicationDocumentService : IApplicationDocumentService
{
    private readonly IDocumentService _documentService;
    private readonly IMapper _mapper;

    public ApplicationDocumentService(IDocumentService documentService, IMapper mapper)
    {
        _documentService = documentService;
        _mapper = mapper;
    }

    public async Task<Document> Add(DocumentDto obj)
    {
        var documents = _mapper.Map<Document>(obj);
        var response = await _documentService.Add(documents);
        return response;
    }

    public async Task<DocumentDto> GetById(Guid id)
    {
        var documents = await _documentService.GetById(id);
        var documentDto = _mapper.Map<DocumentDto>(documents);

        return documentDto;
    }

    public async Task<PagesDocumentDto> GetAll(int page)
    {
        var pages = new PagesDocumentDto();
        const int pageResults = 10;

        var documents = await _documentService.GetAll();
        var result = documents.Skip((page - 1) * pageResults).Take(pageResults).ToList();

        var toPages = _mapper.Map<List<DocumentDto>>(result);
        pages = _mapper.Map<PagesDocumentDto>(toPages);

        pages.CurrentPage = page;
        pages.Pages = (int)Math.Ceiling(documents.Count() / 10f);

        return pages;
    }

    public async Task<Document> Update(DocumentUpdateDto obj)
    {
        var result = _mapper.Map<Document>(obj);
        var response = await _documentService.Update(result);
        return response;
    }

    public async Task<Document> Patch(DocumentPatchDto obj)
    {
        var result = _mapper.Map<Document>(obj);
        var response = await _documentService.Patch(result);
        return response;
    }

    public async Task<Document> Remove(Guid id)
    {
        return await _documentService.Remove(id);
    }
}