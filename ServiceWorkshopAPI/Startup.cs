using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using ServiceWorkshopAPI.Data.Contracts;
using ServiceWorkshopAPI.Data.DataContexts;
using ServiceWorkshopAPI.Data.Services;
using System;

namespace ServiceWorkshopAPI
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
			services.AddScoped<ICustomerService, CustomerService>();
			services.AddScoped<IVehicleService, VehicleService>();
			services.AddScoped<IBookingService, BookingService>();
			services.AddSingleton<ILogger, Logger<Startup>>();

			string connectionString = Configuration["ConnectionStrings:DbContext"];
			services.AddDbContext<ServiceWorkshopDbContext>(options =>
				options.UseSqlServer(connectionString));

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "ServiceWorkshopAPI", Version = "v1" });
			});

			services.AddControllers()
				.AddNewtonsoftJson(opts => opts.SerializerSettings.ContractResolver = new DefaultContractResolver());
			services.AddMvc(options => options.EnableEndpointRouting = false);
			services.AddHttpContextAccessor();
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ServiceWorkshopAPI v1"));
			}

			app.UseCors(c =>
			{
				c.AllowAnyHeader();
				c.AllowAnyMethod();
				c.AllowAnyOrigin();
			});

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();
			app.UseMvc();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
