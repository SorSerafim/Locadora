using Locadora.Data.Repositories;
using Locadora.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Locadora.Data.ExtensionsData
{
    public static class ServiceExtension
    {
        public static void AddData(this IServiceCollection services, IConfiguration Configuration)
        {
            //services.AddAutoMapper(Assembly.GetAssembly(typeof(LocadoraContext)));
            //Services.AddDbContext<LocadoraContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("LocadoraConnection")));
            services.AddTransient<IDiretorRepository, DiretorRepository>();
            services.AddTransient<IFilmeRepository, FilmeRepository>();
            services.AddTransient<IGeneroRepository, GeneroRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
