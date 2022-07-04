using System.Collections.Generic;
using AutoMapper;
using Infrastructure.Shared.Entities;
using Stock.Application.Models;
using Stock.Domain.Entities;

namespace Stock.Application.Map
{
	public class PagesMapper : Profile
	{
		public PagesMapper()
		{
			CreateMap<PagesBase<Movements>, PagesMovementsModel>().ReverseMap();
			CreateMap<PagesBase<ProductsMovement>, PagesProductsModel>().ReverseMap();
		}
	}
}