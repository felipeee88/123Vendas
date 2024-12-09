using _123Vendas.Application.Commands.AtualizarVenda;
using _123Vendas.Application.Commands.CancelarVenda;
using _123Vendas.Application.Commands.CriarVenda;
using _123Vendas.Application.Queries;
using _123Vendas.Domain.Interface.Repository;
using _123Vendas.Domain.Interface.Service;
using _123Vendas.Domain.Service;
using _123Vendas.Infra.Context;
using _123Vendas.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace _123Vendas.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IVendasService, VendasService>();

            services.AddTransient<IVendasRepository, VendasRepository>();

            #region MediatR

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<CriarVendasCommand>();
                cfg.RegisterServicesFromAssemblyContaining<AtualizarVendasCommandHandler>();
                cfg.RegisterServicesFromAssemblyContaining<CancelarVendasCommandHandler>();
                cfg.RegisterServicesFromAssemblyContaining<ListarVendasPorClienteIdQueryHandler>();
                cfg.RegisterServicesFromAssemblyContaining<ListarTodasVendasQueryHandler>();
                cfg.RegisterServicesFromAssemblyContaining<ObterVendasPorIdQueryHandler>();
            });

            #endregion

            return services;
        }
    }
}
