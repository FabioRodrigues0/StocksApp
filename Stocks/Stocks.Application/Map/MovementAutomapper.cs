using System.Collections.Generic;
using AutoMapper;
using Stock.Application.Commands;
using Stock.Application.DTO;
using Stock.Domain.Models;

namespace Stock.Application.Map
{
	public class MovementAutomapper : Profile
	{
		public MovementAutomapper()
		{
			CreateMap<MovementsDto, Movements>().ReverseMap();
			CreateMap<Post, Movements>().ReverseMap();
			CreateMap<(List<MovementsDto> list, int totalPages, int page), (List<Movements> list, int totalPages, int page)>().ReverseMap();
		}
	}
}