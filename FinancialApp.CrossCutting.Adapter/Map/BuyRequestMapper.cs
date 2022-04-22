using FinancialApp.CrossCutting.Adapter.Interfaces;
using FinancialApp.Domain.Models;
using FinancialApp.DTO.DTO;

namespace FinancialApp.CrossCutting.Adapter.Map;

public class BuyRequestMapper : IBuyRequestMapper
{
	#region properties

	private readonly List<BuyRequestDto> _buyRequestDtos = new List<BuyRequestDto>();
	private readonly PagesBuyRequestDto _pagesBuyRequestDto = new PagesBuyRequestDto();
	private readonly BuyRequestProductMapper _productMapper = new BuyRequestProductMapper();

	#endregion properties

	#region methods

	public BuyRequest MapperToEntity(BuyRequestDto buyRequestDto)
	{
		var result = _productMapper.MapProductList(buyRequestDto.Products.ToList());
		decimal t = 0;
		foreach(var p in result)
		{
			t += p.Total;
		}

		var buyRequest = new BuyRequest()
		{
			Id = Guid.NewGuid(),
			Code = buyRequestDto.Code,
			Date = buyRequestDto.Date,
			DeliveryDate = buyRequestDto.DeliveryDate,
			Products = result,
			ClientDescription = buyRequestDto.ClientDescription,
			ClientEmail = buyRequestDto.ClientEmail,
			ClientPhone = buyRequestDto.ClientPhone,
			Status = buyRequestDto.Status,
			Street = buyRequestDto.Street,
			Number = buyRequestDto.Number,
			Sector = buyRequestDto.Sector,
			Complement = buyRequestDto.Complement,
			City = buyRequestDto.City,
			State = buyRequestDto.State,
			Discount = buyRequestDto.Discount,
			Cost = buyRequestDto.Cost,
			ProductValor = t,
			TotalValor = t - buyRequestDto.Discount
		};

		return buyRequest;
	}

	public PagesBuyRequestDto MapperListBuyRequest(List<BuyRequest> buyRequest, int page)
	{
		var pageResults = 10f;
		var pageCount = Math.Ceiling(buyRequest.Count() / pageResults);

		foreach(var br in buyRequest)
		{
			var buyRequestDto = new BuyRequestDto
			{
				Code = br.Code,
				Date = br.Date,
				DeliveryDate = br.DeliveryDate,
				Client = br.Client,
				ClientDescription = br.ClientDescription,
				ClientEmail = br.ClientEmail,
				ClientPhone = br.ClientPhone,
				Status = br.Status,
				Street = br.Street,
				Number = br.Number,
				Sector = br.Sector,
				Complement = br.Complement,
				City = br.City,
				State = br.State,
				Discount = br.Discount,
				Cost = br.Cost,
				Products = _productMapper.MapProductListDto(br.Products.ToList())
			};
			_buyRequestDtos.Add(buyRequestDto);
		}

		_pagesBuyRequestDto.Models = _buyRequestDtos;
		_pagesBuyRequestDto.CurrentPage = page;
		_pagesBuyRequestDto.Pages = (int)pageCount;

		return _pagesBuyRequestDto;
	}

	public BuyRequestDto MapperToDTO(BuyRequest buyRequest)
	{
		var buyRequestDto = new BuyRequestDto
		{
			Code = buyRequest.Code,
			Date = buyRequest.Date,
			DeliveryDate = buyRequest.DeliveryDate,
			Client = buyRequest.Client,
			ClientDescription = buyRequest.ClientDescription,
			ClientEmail = buyRequest.ClientEmail,
			ClientPhone = buyRequest.ClientPhone,
			Status = buyRequest.Status,
			Street = buyRequest.Street,
			Number = buyRequest.Number,
			Sector = buyRequest.Sector,
			Complement = buyRequest.Complement,
			City = buyRequest.City,
			State = buyRequest.State,
			Discount = buyRequest.Discount,
			Cost = buyRequest.Cost,
			Products = _productMapper.MapProductListDto(buyRequest.Products.ToList())
		};
		return buyRequestDto;
	}

	#endregion methods
}