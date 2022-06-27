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
	public sealed class GetByIdHandler : ValidationsBase<Movements>, IRequestHandler<GetById, MovementsDto>
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

		public async Task<MovementsDto> Handle(GetById request, CancellationToken cancellationToken)
		{
			var result = await _MovementsRepository.GetByIdAsync(request.Id);
			if (result == null)
			{
				_logger.LogInformation("No Content");
				NoContent(false);
			}
			return _mapper.Map<MovementsDto>(result);
		}
	}
}