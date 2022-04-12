using FinancialApp.Application.Interface;
using FinancialApp.Domain.Core.Services;
using FinancialApp.DTO.DTO;

namespace FinancialApp.Application.Service;

public class ApplicationServiceCashBook : IApplicationServiceCashBook
{
	private readonly IServiceCashBook _serviceCashBook;
	//private readonly IMapperCashBook _mapperCliente;

	public ApplicationServiceCashBook(IServiceCashBook ServiceCashBook)
	//, IMapperCashBook MapperCliente)

	{
		_serviceCashBook = ServiceCashBook;
		//_mapperCliente = MapperCliente;
	}

	public void Add(CashBookDTO obj)
	{
		throw new NotImplementedException();
	}

	public CashBookDTO GetById(int id)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<CashBookDTO> GetAll()
	{
		throw new NotImplementedException();
	}

	public void Update(CashBookDTO obj)
	{
		throw new NotImplementedException();
	}

	public void Remove(CashBookDTO obj)
	{
		throw new NotImplementedException();
	}

	public void Dispose()
	{
		throw new NotImplementedException();
	}
}