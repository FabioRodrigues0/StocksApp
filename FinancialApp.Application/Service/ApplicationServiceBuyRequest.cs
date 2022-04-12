using FinancialApp.Application.Interface;
using FinancialApp.Domain.Core.Services;
using FinancialApp.DTO.DTO;

namespace FinancialApp.Application.Service;

public class ApplicationServiceBuyRequest : IApplicationServiceBuyRequest
{
	private readonly IServiceBuyRequest _serviceBuyRequest;
	//private readonly IMapperCashBook _mapperCliente;

	public ApplicationServiceBuyRequest(IServiceBuyRequest ServiceBuyRequest)
	//, IMapperCashBook MapperCliente)

	{
		_serviceBuyRequest = ServiceBuyRequest;
		//_mapperCliente = MapperCliente;
	}

	public void Add(BuyRequestDTO obj)
	{
		throw new NotImplementedException();
	}

	public BuyRequestDTO GetById(int id)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<BuyRequestDTO> GetAll()
	{
		throw new NotImplementedException();
	}

	public void Update(BuyRequestDTO obj)
	{
		throw new NotImplementedException();
	}

	public void Remove(BuyRequestDTO obj)
	{
		throw new NotImplementedException();
	}

	public void Dispose()
	{
		throw new NotImplementedException();
	}
}