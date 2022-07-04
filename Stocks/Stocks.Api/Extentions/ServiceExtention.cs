using Infrastructure.Shared.Services;
using Infrastructure.Shared.Services.Interface;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Stock.Application.Application.Handlers.Dashboard;
using Stock.Application.Application.Handlers.Movement;
using Stock.Application.Application.Handlers.Products;
using Stock.Application.Commands;
using Stock.Application.Models;
using Stock.Application.Queries;
using Stock.Data.Repositories;
using Stock.Data.Repositories.Interfaces;
using Stock.Domain.Entities;

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
			services.AddTransient<IRequestHandler<Delete, bool>, DeleteHandler>();
			services.AddTransient<IRequestHandler<Post, Movements>, PostHandler>();
			services.AddTransient<IRequestHandler<GetAll, PagesMovementsModel>, GetAllHandler>();
			services.AddTransient<IRequestHandler<GetById, MovementsModel>, GetByIdHandler>();
			//Products
			services.AddTransient<IRequestHandler<GetAllProducts, PagesProductsModel>, GetAllProductsHandler>();
			services.AddTransient<IRequestHandler<GetProductById, ProductsMovementModel>, GetProductByIdHandler>();
			services.AddTransient<IRequestHandler<GetProductByIdWithStorageId, ProductsMovementModel>, GetProductByIdWithStorageIdHandler>();
			//Dashboard
			services.AddTransient<IRequestHandler<GetAllDashboard, PagesProductsModel>, GetAllDashboardHandler>();
			services.AddTransient<IRequestHandler<GetTopFive, PagesProductsModel>, GetTopFiveHandler>();
		}
	}
}