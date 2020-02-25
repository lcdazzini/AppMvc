using AutoMapper;
using KissLog.Apis.v1.Listeners;
using KissLog.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudyIO.App.Configuration;
using StudyIO.Data.Context;

namespace StudyIO.App
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IWebHostEnvironment hostEnvironment)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(hostEnvironment.ContentRootPath)
				.AddJsonFile("appsettings.json", true, true)
				.AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
				.AddEnvironmentVariables();

			if (hostEnvironment.IsDevelopment())
			{
				builder.AddUserSecrets<Startup>();
			}

			Configuration = builder.Build();
		}


		public void ConfigureServices(IServiceCollection services)
		{
			services.AddIdentityConfiguration(Configuration);

			services.AddDbContext<StudyIODbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddControllersWithViews().AddRazorRuntimeCompilation();
			services.AddRazorPages();

			services.AddAutoMapper(typeof(Startup));

			services.AddMvcConfiguration();

			services.ResolveDependencies();


		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/erro/500");
				app.UseStatusCodePagesWithRedirects("/erro/{0}");
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseAuthentication();

			app.UseGlobalizationConfiguration();

			app.UseRouting();

			app.UseKissLogMiddleware(options => {
				options.Listeners.Add(new KissLogApiListener(new KissLog.Apis.v1.Auth.Application(
					Configuration["KissLog.OrganizationId"],
					Configuration["KissLog.ApplicationId"])
				));
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
			});
		}
	}
}
