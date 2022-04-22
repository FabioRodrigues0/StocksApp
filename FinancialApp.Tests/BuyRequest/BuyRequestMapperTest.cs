using AutoMapper;
using FinancialApp.CrossCutting.Adapter.Map;
using FinancialApp.DTO.DTO;
using Xunit;

namespace FinancialApp.Tests.BuyRequest;

public class BuyRequestMapperTest
{
	[Fact]
	public void MapperToEntity_Test()
	{
		var mapper = new BuyRequestMapper();
	}
}