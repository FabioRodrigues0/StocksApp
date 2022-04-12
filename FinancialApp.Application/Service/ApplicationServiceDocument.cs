using FinancialApp.Application.Interface;
using FinancialApp.Domain.Core.Services;
using FinancialApp.DTO.DTO;

namespace FinancialApp.Application.Service;

public class ApplicationServiceDocument : IApplicationServiceDocument
{
	private readonly IServiceDocument _serviceDocument;
	//private readonly IMapperDocument _mapperDocument;

	public ApplicationServiceDocument(IServiceDocument ServiceDocument)
	//, IMapperCashBook MapperCliente)

	{
		_serviceDocument = ServiceDocument;
		//_mapperCliente = MapperCliente;
	}

	public void Add(DocumentDTO obj)
	{
		throw new NotImplementedException();
	}

	public DocumentDTO GetById(int id)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<DocumentDTO> GetAll()
	{
		throw new NotImplementedException();
	}

	public void Update(DocumentDTO obj)
	{
		throw new NotImplementedException();
	}

	public void Remove(DocumentDTO obj)
	{
		throw new NotImplementedException();
	}

	public void Dispose()
	{
		throw new NotImplementedException();
	}
}