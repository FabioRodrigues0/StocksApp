global using AutoMapper;
global using FinancialApp.Domain.Models;
using FinancialApp.Application.Interface;
using FinancialApp.Application.Service;
using FinancialApp.CrossCutting.Adapter.Map;
using FinancialApp.Data;
using FinancialApp.Data.Repositories;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Core.Services;
using FinancialApp.Domain.Models.Validations;
using FinancialApp.Domain.Services.Services;
using FinancialApp.Shared;
using FinancialApp.Shared.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation(fv =>
{
	fv.RegisterValidatorsFromAssemblyContaining<BuyRequestValidations>();
}).AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddTransient<IValidator<BuyRequest>, BuyRequestValidations>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(Program));
var config = new MapperConfiguration(cfg =>
{
	cfg.AddProfile(new BuyRequestAutoMapper());
	cfg.AddProfile(new BuyRequestProductAutoMapper());
	cfg.AddProfile(new PagesBuyRequestMapper());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IApplicationBuyRequestService, ApplicationBuyRequestService>();
builder.Services.AddScoped<IBuyRequestService, BuyRequestService>();
builder.Services.AddScoped<IBuyRequestProductService, BuyRequestProductService>();
builder.Services.AddScoped<IBuyRequestProductsRepository, BuyRequestProductsRepository>();
builder.Services.AddScoped<IBuyRequestRepository, BuyRequestRepository>();
builder.Services.AddScoped<IServiceContext, ServiceContext>();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();