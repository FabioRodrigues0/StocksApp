using Infrastructure.Shared.Services;
using Infrastructure.Shared.Services.Interface;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Stock.Application.Application.Handlers.Dashboard;
using Stock.Application.Application.Handlers.Movement;
using Stock.Application.Application.Handlers.Products;
using Stock.Application.Commands;
using Stock.Application.DTO;
using Stock.Application.Queries;
using Stock.Data.Repositories;
using Stock.Data.Repositories.Interfaces;
using Stock.Domain.Models;

namespace Stock.Api.Extentions
{
	public static class ServiceExtention
	{
		public static void AddService(this IServiceCollection services)
		{
			services.AddScoped<IProductsMovementRepository, ProductsMovementRepository>();
			services.AddScoped<IMovementsRepository, MovementsRepository>();
			services.AddScoped<IDashBoardRepository, DashBoardRepository>();
			services.AddScoped<IServiceContext, ServiceContext>();
			//Movement
			services.AddTransient<IRequestHandler<Post, Movements>, PostHandler>();
			services.AddTransient<IRequestHandler<GetAll, PagesMovementsDto>, GetAllHandler>();
			services.AddTransient<IRequestHandler<GetById, MovementsDto>, GetByIdHandler>();
			//Products
			services.AddTransient<IRequestHandler<GetAllProducts, PagesProductsDto>, GetAllProductsHandler>();
			services.AddTransient<IRequestHandler<GetProductById, ProductsMovementDto>, GetProductByIdHandler>();
			services.AddTransient<IRequestHandler<GetProductByIdWithStorageId, ProductsMovementDto>, GetProductByIdWithStorageIdHandler>();
			//Dashboard
			services.AddTransient<IRequestHandler<GetAllDashboard, PagesProductsDto>, GetAllDashboardHandler>();
			services.AddTransient<IRequestHandler<GetTopFive, PagesProductsDto>, GetTopFiveHandler>();
		}
	}
}