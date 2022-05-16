global using CashBook.Domain.Models;
using CashBook.Api;
using CashBook.Api.Extentions;
using CashBook.Data;
using CashBook.Domain.Models.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var ConsoleLoggerFactory = LoggerFactory.Create(builder => { builder.AddDebug(); });

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation(fv =>
{
	fv.RegisterValidatorsFromAssemblyContaining<CashBookValidations>();
});
builder.Services.AddTransient<IValidator<CashBooks>, CashBookValidations>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CashBookContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
		.UseLoggerFactory(ConsoleLoggerFactory)
		.EnableSensitiveDataLogging();
});

builder.Services.AddHttpClient();
builder.Services.AddService();
builder.Services.AddMapper();

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