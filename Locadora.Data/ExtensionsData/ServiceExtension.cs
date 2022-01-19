using Locadora.Data.Repositories;
using Locadora.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Locadora.Data.ExtensionsData
{
    public static class ServiceExtension
    {
        public static void AddData(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<LocadoraContext>(x => x.UseSqlServer(Configuration.GetConnectionString("LocadoraConnection")));
            services.BuildServiceProvider().GetService<LocadoraContext>().Database.Migrate();
            services.AddTransient<IDiretorRepository, DiretorRepository>();
            services.AddTransient<IFilmeRepository, FilmeRepository>();
            services.AddTransient<IGeneroRepository, GeneroRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
