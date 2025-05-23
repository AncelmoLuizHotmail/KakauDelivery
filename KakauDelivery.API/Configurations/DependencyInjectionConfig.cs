﻿using KakauDelivery.Application.Applications.Cliente;
using KakauDelivery.Application.Applications.Interfaces;
using KakauDelivery.Application.Applications.Pedido;
using KakauDelivery.Application.Applications.Usuario;
using KakauDelivery.Application.Services;
using KakauDelivery.Application.Services.Interfaces;
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IClienteApp, ClienteApp>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteRepositoryReadOnly, ClienteRepositoryReadOnly>();

            services.AddScoped<IPedidoApp, PedidoApp>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoRepositoryReadOnly, PedidoRepositoryReadOnly>();

            services.AddScoped<IUsuarioApp, UsuarioApp>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioRepositoryReadOnly, UsuarioRepositoryReadOnly>();
        }
    }
}
