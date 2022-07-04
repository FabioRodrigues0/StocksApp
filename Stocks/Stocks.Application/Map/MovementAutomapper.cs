using System.Collections.Generic;
using AutoMapper;
using Stock.Application.Commands;
using Stock.Application.Models;
using Stock.Domain.Entities;

namespace Stock.Application.Map
{
	public class MovementAutomapper : Profile
	{
		public MovementAutomapper()
		{
			CreateMap<MovementsModel, Movements>().ReverseMap();
			CreateMap<Post, Movements>().ReverseMap();
		}
	}
}