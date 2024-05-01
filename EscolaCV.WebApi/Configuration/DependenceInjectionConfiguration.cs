using EscolaCV.Infra.Repository;
using EscolaCV.Manager.Implementation;
using EscolaCV.Manager.Interfaces.IEscola;
using EscolaCV.Manager.Interfaces.IPais;
using EscolaCV.Manager.Interfaces.IProvincia;
using ProvinciaCV.Manager.Implementation;
using ProvinciaCV.Manager.Interfaces.IProvincia;

namespace EscolaCV.WebApi.Configuration
{
    public static class DependenceInjectionConfiguration
    {

        public static void AddDependenceInjectionConfiguration(this IServiceCollection services)
        {

            services.AddScoped<IEscolaManager, EscolaManager>();
            services.AddScoped<IEscolaRepository, EscolaRepository>();

            services.AddScoped<IPaisManager, PaisManager>();
            services.AddScoped<IPaisRepository, PaisRepository>();

            services.AddScoped<IProvinciaManager, ProvinciaManager>();
            services.AddScoped<IProvinciaRepository, ProvinciaRepository>();

        }
    }
}
