#region Imports

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

#endregion

namespace Stock.Application.Application.Handlers.Movement
{
	public class PostHandler : ValidationsBase<Movements>, IRequestHandler<Post, Movements>
	{
		private readonly IMovementsRepository _MovementsRepository;
		private readonly IMapper _mapper;

		public PostHandler(
			IMovementsRepository movementsRepository,
			IMapper mapper,
			IServiceContext serviceContext,
			ILogger<PostHandler> logger) : base(logger, serviceContext)
		{
			_MovementsRepository = movementsRepository;
			_mapper = mapper;
		}

		public async Task<Movements> Handle(Post request, CancellationToken cancellationToken)
		{
			var result = request.Movements;
			var model = _mapper.Map<Movements>(result);
			ValidateEntity(model);
			//AddNotification("Erro de negocio");
			if (!IsValidOperation)
				return null;
			return await _MovementsRepository.AddAsync(model);
		}
	}
}