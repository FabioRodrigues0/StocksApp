using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Shared.Services;
using Infrastructure.Shared.Services.Interface;
using MediatR;
using Microsoft.Extensions.Logging;
using Stock.Application.DTO;
using Stock.Application.Queries;
using Stock.Data.Repositories.Interfaces;
using Stock.Domain.Models;

namespace Stock.Application.Application.Handlers.Movement
{
	public sealed class GetAllHandler : ValidationsBase<Movements>, IRequestHandler<GetAll, PagesMovementsDto>
	{
		private readonly IMovementsRepository _movementsRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<GetAllHandler> _logger;

		public GetAllHandler(
			IMovementsRepository movementsRepository,
			IServiceContext serviceContext,
			IMapper mapper,
			ILogger<GetAllHandler> logger) : base(logger, serviceContext)
		{
			_movementsRepository = movementsRepository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<PagesMovementsDto> Handle(GetAll request, CancellationToken cancellationToken)
		{
			var result = await _movementsRepository.GetAllAsync(request.page);
			if (result.list.Count == 0)
			{
				_logger.LogInformation("No Content");
				NoContent(false);
			}
			var toPages = _mapper.Map<(List<MovementsDto> list, int totalPages, int page)>(result);
			return _mapper.Map<PagesMovementsDto>(toPages);
		}
	}
}