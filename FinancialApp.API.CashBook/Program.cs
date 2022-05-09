global using FinancialApp.Domain.Models;
using AutoMapper;
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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation(fv =>
{
	fv.RegisterValidatorsFromAssemblyContaining<CashBookValidations>();
});
builder.Services.AddTransient<IValidator<CashBook>, CashBookValidations>();
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
	cfg.AddProfile(new CashBookAutoMapper());
	cfg.AddProfile(new PagesCashBookMapper());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IApplicationCashBookService, ApplicationCashBookService>();
builder.Services.AddScoped<ICashBookService, CashBookService>();
builder.Services.AddScoped<ICashBookRepository, CashBookRepository>();
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