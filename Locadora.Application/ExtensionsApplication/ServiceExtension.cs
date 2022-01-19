using Locadora.Application.Services;
using Locadora.Domain.Interfaces.ServiceInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Locadora.Application.ExtensionsApplication
{
    public static class ServiceExtension
    {
        public static void AddAplication(this IServiceCollection services)
        {
            services.AddTransient<IDiretorService, DiretorService>();
            services.AddTransient<IFilmeService, FilmeService>();
            services.AddTransient<IGeneroService, GeneroService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
