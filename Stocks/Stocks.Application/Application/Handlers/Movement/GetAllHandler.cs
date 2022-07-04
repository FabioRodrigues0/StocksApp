using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Shared.Services;
using Infrastructure.Shared.Services.Interface;
using MediatR;
using Microsoft.Extensions.Logging;
using Stock.Application.Models;
using Stock.Application.Queries;
using Stock.Data.Repositories.Interfaces;
using Stock.Domain.Entities;

namespace Stock.Application.Application.Handlers.Movement
{
	public sealed class GetAllHandler : ValidationsBase<Movements>, IRequestHandler<GetAll, PagesMovementsModel>
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

		public async Task<PagesMovementsModel> Handle(GetAll request, CancellationToken cancellationToken)
		{
			var result = await _movementsRepository.GetAllAsync(request.page, request.itemsPerPage);
			if (result.Models.Count == 0)
			{
				_logger.LogInformation("No Content");
				NoContent(false);
			}
			return _mapper.Map<PagesMovementsModel>(result);
		}
	}
}