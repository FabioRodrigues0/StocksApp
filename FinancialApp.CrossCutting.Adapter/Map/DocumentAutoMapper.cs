using AutoMapper;
using FinancialApp.Domain.Models;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Map;

public class DocumentAutoMapper : Profile
{
    public DocumentAutoMapper()
    {
        CreateMap<Document, DocumentDto>().ReverseMap();
        CreateMap<Document, DocumentUpdateDto>().ReverseMap();
        CreateMap<Document, DocumentPatchDto>().ReverseMap();
    }
}