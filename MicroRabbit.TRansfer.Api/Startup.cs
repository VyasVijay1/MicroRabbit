using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.IoC;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Rabbit.EventHandlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MicroRabbit.TRansfer.Api
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
			services.AddDbContext<TransferDbContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("TransferDbConnection"));
			});
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Transfer Microservice", Version = "v1" });
			});

			services.AddMediatR(typeof(Startup));
			RegisterServices(services);
		}

		private void RegisterServices(IServiceCollection services)
		{
			DependencyContainer.RegisterServices(services);
		}
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseSwagger();
			app.UseSwaggerUI(
				c => {
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking Microsevice V1");
				}
				);
			app.UseMvc();
			ConfigureEventBus(app);
		}

		private void ConfigureEventBus(IApplicationBuilder app)
		{
			var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
			eventBus.Subscribe<TransferCreatedEvents, TransferEventHandler>();
		}
	}
}
