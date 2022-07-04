using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Shared.Enums;
using Infrastructure.Shared.Services;
using Infrastructure.Shared.Services.Interface;
using MediatR;
using Microsoft.Extensions.Logging;
using Stock.Application.Commands;
using Stock.Data.Repositories.Interfaces;
using Stock.Domain.Entities;

namespace Stock.Application.Application.Handlers.Movement
{
	public class DeleteHandler : ValidationsBase<Movements>, IRequestHandler<Delete, bool>
	{
		private readonly IMovementsRepository _MovementsRepository;
		private readonly IMapper _mapper;

		public DeleteHandler(
			IMovementsRepository movementsRepository,
			IMapper mapper,
			IServiceContext serviceContext,
			ILogger<GetByIdHandler> logger) : base(logger, serviceContext)
		{
			_MovementsRepository = movementsRepository;
			_mapper = mapper;
		}

		public async Task<bool> Handle(Delete request, CancellationToken cancellationToken)
		{
			var obj = await _MovementsRepository.GetByIdAsync(request.Id);
			if (obj == null)
				return true;
			var result = await _MovementsRepository.RemoveAsync(request.Id);
			return result;
		}
	}
}