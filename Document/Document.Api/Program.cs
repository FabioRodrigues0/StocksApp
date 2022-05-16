global using AutoMapper;
global using Document.Domain.Models;
using Document.Data;
using Document.Domain.Models.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using CashBook.ApiClient;
using Document.Api.Extentions;

var builder = WebApplication.CreateBuilder(args);
var ConsoleLoggerFactory = LoggerFactory.Create(builder => { builder.AddDebug(); });

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation(fv =>
{
	fv.RegisterValidatorsFromAssemblyContaining<DocumentValidations>();
});
builder.Services.AddTransient<IValidator<Documents>, DocumentValidations>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DocumentContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
		.UseLoggerFactory(ConsoleLoggerFactory)
		.EnableSensitiveDataLogging();
});

builder.Services.AddHttpClient();
builder.Services.AddService();
builder.Services.AddMapper();
builder.Services.AddCashBankConfiguration(builder.Configuration);

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