using KakauDelivery.Application.Applications.Cliente;
using KakauDelivery.Application.Applications.Interfaces;
using KakauDelivery.Application.Services.Interfaces;
using KakauDelivery.Application.Services;
using KakauDelivery.Domain.Repositories.Repository;
using KakauDelivery.Domain.Repositories.RepositoryReadOnly;
using KakauDelivey.Infra.Repositories;
using KakauDelivey.Infra.RepositoriesReadOnly;

namespace KakauDelivery.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteApp, ClienteApp>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteRepositoryReadOnly, ClienteRepositoryReadOnly>();
        }
    }
}
