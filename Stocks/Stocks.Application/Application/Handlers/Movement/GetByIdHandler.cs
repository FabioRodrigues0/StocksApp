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
	public sealed class GetByIdHandler : ValidationsBase<Movements>, IRequestHandler<GetById, MovementsModel>
	{
		private readonly IMovementsRepository _MovementsRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<GetByIdHandler> _logger;

		public GetByIdHandler(
			IMovementsRepository movementsRepository,
			IMapper mapper,
			IServiceContext serviceContext,
			ILogger<GetByIdHandler> logger) : base(logger, serviceContext)
		{
			_MovementsRepository = movementsRepository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<MovementsModel> Handle(GetById request, CancellationToken cancellationToken)
		{
			var result = await _MovementsRepository.GetByIdAsync(request.Id);
			if (result == null)
			{
				_logger.LogInformation("No Content");
				NoContent(false);
			}
			return _mapper.Map<MovementsModel>(result);
		}
	}
}