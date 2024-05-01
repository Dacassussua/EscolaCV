using AutoMapper;
using EscolaCV.Manager.Implementation;
using EscolaCV.Manager.Interfaces.IPais;

namespace EscolaCV.WebApi.Configuration
{
    public static class DataMiddlewareExtensions
    {
        private static ServiceProvider _serviceProvider;
        public static void UseUseSeedDataMiddleware(this IServiceCollection services)
        {
            _serviceProvider = services.BuildServiceProvider();

            new DataMiddlewareManager(_serviceProvider);

        }

    }
}
