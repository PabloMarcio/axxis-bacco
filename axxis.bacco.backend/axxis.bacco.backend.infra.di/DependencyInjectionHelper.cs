using axxis.bacco.backend.infra.data.Repositories.Comandas;
using axxis.bacco.domain.Comandas.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace axxis.bacco.backend.infra.di
{
    public class DependencyInjectionHelper
    {
        public static void Configure(IServiceCollection services)
        {
            //repositories
            services.AddScoped<IComandaRepository, ComandaRepository>();
        }
    }
}