using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Shared.Services;
using Infrastructure.Shared.Services.Interface;
using MediatR;
using Microsoft.Extensions.Logging;
using Stock.Application.Commands;
using Stock.Data.Repositories.Interfaces;
using Stock.Domain.Models;

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
			return await _MovementsRepository.RemoveAsync(request.Id);
		}
	}
}