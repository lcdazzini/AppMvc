using KissLog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using StudyIO.App.Extensions;
using StudyIO.Business.Interfaces;
using StudyIO.Business.Notifications;
using StudyIO.Business.Services;
using StudyIO.Data.Context;
using StudyIO.Data.Repository;

namespace StudyIO.App.Configuration
{
	public static class DependencyInjectionConfiguration 
	{
		public static IServiceCollection ResolveDependencies(this IServiceCollection services)
		{
			services.AddScoped<StudyIODbContext>();
			services.AddScoped<IProdutoRepository, ProdutoRepository>();
			services.AddScoped<IEnderecoRepository, EnderecoRepository>();
			services.AddScoped<IFornecedorRepository, FornecedorRepository>();
			services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

			services.AddScoped<INotificador, Notificador>();
			services.AddScoped<IFornecedorService, FornecedorService>();
			services.AddScoped<IProdutoService, ProdutoService>();

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped(context => Logger.Factory.Get());

			return services;
		}
	}
}
