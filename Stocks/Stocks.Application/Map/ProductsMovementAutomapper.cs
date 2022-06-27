using System.Collections.Generic;
using AutoMapper;
using Stock.Application.DTO;
using Stock.Domain.Models;

namespace Stock.Application.Map
{
	public class ProductsMovementAutomapper : Profile
	{
		public ProductsMovementAutomapper()
		{
			CreateMap<ProductsMovementDto, ProductsMovement>().ReverseMap();
			CreateMap<(List<ProductsMovementDto> list, int totalPages, int page), (List<ProductsMovement> list, int totalPages, int page)>().ReverseMap();
		}
	}
}