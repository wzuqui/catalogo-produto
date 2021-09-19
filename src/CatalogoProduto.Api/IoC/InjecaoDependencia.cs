using System;
using CatalogoProduto.Api.Filters;
using CatalogoProduto.Domain;
using CatalogoProduto.Domain.Core;
using CatalogoProduto.Domain.Core.Interfaces;
using CatalogoProduto.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogoProduto.Api.IoC
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection AdicionarIoC(this IServiceCollection pServices)
        {
            return pServices
                    .AdicionarRepositories()
                    .AdicionarServices()
                    .AdicionarAutoMapper()
                    .AddTransient<ModelStateFilter>()
                    .AddScoped<Notificacoes>()
                ;
        }

        private static IServiceCollection AdicionarAutoMapper(this IServiceCollection pServices)
        {
            return pServices
                    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                ;
        }

        private static IServiceCollection AdicionarRepositories(this IServiceCollection pServices)
        {
            return pServices
                    .AddScoped<IProdutoRepository, ProdutoRepository>()
                ;
        }

        private static IServiceCollection AdicionarServices(this IServiceCollection pServices)
        {
            return pServices
                    .AddScoped<IProdutoService, ProdutoService>()
                ;
        }
    }
}