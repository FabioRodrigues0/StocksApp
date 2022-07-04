#region Imports

using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Shared.Messaging.Settings;
using MediatR;
using MessageBroker.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Stock.Api.Extentions;
using Stock.Data;
using Stock.Domain.Entities;
using Stock.Domain.Entities.Validations;

#endregion

namespace Stock.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var ConsoleLoggerFactory = LoggerFactory.Create(builder => { builder.AddDebug(); });
			services.AddControllers().AddFluentValidation(fv =>
			{
				fv.RegisterValidatorsFromAssemblyContaining<MovementsValidations>();
			});
			services.AddTransient<IValidator<Movements>, MovementsValidations>();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Stocks.Api", Version = "v1" });
			});
			services.AddDbContext<MovementsContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
					.UseLoggerFactory(ConsoleLoggerFactory)
					.EnableSensitiveDataLogging();
			});
			services.AddMediatR(typeof(Startup));
			services.AddHttpClient();
			services.AddMapper();
			services.AddService();
			services.AddConsumer();
			services.AddListener(Configuration);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stocks.Api v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}