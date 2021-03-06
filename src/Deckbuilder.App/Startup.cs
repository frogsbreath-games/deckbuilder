﻿using Deckbuilder.App.Hubs;
using Deckbuilder.App.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Deckbuilder.App
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
			services.AddControllersWithViews()
				.AddNewtonsoftJson(options =>
				{
					options.SerializerSettings.Converters.Add(
						new StringEnumConverter(new CamelCaseNamingStrategy(true, true)));

					options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

					JsonConvert.DefaultSettings = () => options.SerializerSettings;
				});

			services.AddOpenApiDocument();

			// In production, the React files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/build";
			});

			services.AddSingleton<BoardSingletonRepo>();

			services.AddScoped<IRandomAccessor, RandomAccessor>();
			services.AddScoped<IBoardUpdater, BoardUpdater>();
			services.AddScoped<IBoardGenerator, BoardGenerator>();

			services.AddSignalR()
				.AddNewtonsoftJsonProtocol(options =>
				{
					options.PayloadSerializerSettings.Converters.Add(
						new StringEnumConverter(new CamelCaseNamingStrategy(false, true)));
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSpaStaticFiles();

			app.UseRouting();

			app.UseOpenApi();
			app.UseSwaggerUi3();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapHub<BoardHub>("/hubs/board");
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
				{
					spa.UseReactDevelopmentServer(npmScript: "start");
				}
			});
		}
	}
}
