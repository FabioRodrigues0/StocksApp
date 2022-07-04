using System.Collections.Generic;
using AutoMapper;
using Stock.Application.Models;
using Stock.Domain.Entities;

namespace Stock.Application.Map
{
	public class ProductsMovementAutomapper : Profile
	{
		public ProductsMovementAutomapper()
		{
			CreateMap<ProductsMovementModel, ProductsMovement>().ReverseMap();
		}
	}
}