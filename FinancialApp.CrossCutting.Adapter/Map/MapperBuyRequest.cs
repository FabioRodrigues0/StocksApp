using FinacialApp.Domain.Models;
using FinacialApp.Shared;
using FinancialApp.CrossCutting.Adapter.Interfaces;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Map;

public class MapperBuyRequest : IMapperBuyRequest
{
	#region properties

	private readonly List<BuyRequestDTO> _buyRequestDtos = new List<BuyRequestDTO>();

	#endregion properties

	#region methods

	public BuyRequest MapperToEntity(BuyRequestDTO buyRequestDto)
	{
		BuyRequest buyRequest = new BuyRequest()
		{
			Id = buyRequestDto.Id,
			Code = buyRequestDto.Code,
			Date = buyRequestDto.Date,
			DateDelivery = buyRequestDto.DateDelivery,
			Client = buyRequestDto.Client,
			ClientDescription = buyRequestDto.ClientDescription,
			ClientEmail = buyRequestDto.ClientEmail,
			ClientPhoneNumber = buyRequestDto.ClientPhoneNumber,
			Status = buyRequestDto.Status,
			Address = buyRequestDto.Address,
			AddressNumber = buyRequestDto.AddressNumber,
			ZipCode = buyRequestDto.ZipCode,
			AddressDescription = buyRequestDto.AddressDescription,
			City = buyRequestDto.City,
			State = buyRequestDto.State,
			ProductValor = buyRequestDto.ProductValor,
			Descont = buyRequestDto.Descont,
			CostValor = buyRequestDto.CostValor,
			TotalValor = buyRequestDto.TotalValor
		};
		return buyRequest;
	}

	public IEnumerable<BuyRequestDTO> MapperListBuyRequest(IEnumerable<BuyRequest> buyRequest)
	{
		foreach(var br in buyRequest)
		{
			BuyRequestDTO buyRequestDto = new BuyRequestDTO
			{
				Id = br.Id,
				Code = br.Code,
				Date = br.Date,
				DateDelivery = br.DateDelivery,
				Client = br.Client,
				ClientDescription = br.ClientDescription,
				ClientEmail = br.ClientEmail,
				ClientPhoneNumber = br.ClientPhoneNumber,
				Status = br.Status,
				Address = br.Address,
				AddressNumber = br.AddressNumber,
				ZipCode = br.ZipCode,
				AddressDescription = br.AddressDescription,
				City = br.City,
				State = br.State,
				ProductValor = br.ProductValor,
				Descont = br.Descont,
				CostValor = br.CostValor,
				TotalValor = br.TotalValor
			};
			_buyRequestDtos.Add(buyRequestDto);
		}
		return _buyRequestDtos;
	}

	public BuyRequestDTO MapperToDTO(BuyRequest buyRequest)
	{
		BuyRequestDTO buyRequestDto = new BuyRequestDTO
		{
			Id = buyRequest.Id,
			Code = buyRequest.Code,
			Date = buyRequest.Date,
			DateDelivery = buyRequest.DateDelivery,
			Client = buyRequest.Client,
			ClientDescription = buyRequest.ClientDescription,
			ClientEmail = buyRequest.ClientEmail,
			ClientPhoneNumber = buyRequest.ClientPhoneNumber,
			Status = buyRequest.Status,
			Address = buyRequest.Address,
			AddressNumber = buyRequest.AddressNumber,
			ZipCode = buyRequest.ZipCode,
			AddressDescription = buyRequest.AddressDescription,
			City = buyRequest.City,
			State = buyRequest.State,
			ProductValor = buyRequest.ProductValor,
			Descont = buyRequest.Descont,
			CostValor = buyRequest.CostValor,
			TotalValor = buyRequest.TotalValor
		};
		return buyRequestDto;
	}

	#endregion methods
}