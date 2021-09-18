using System;
using CatalogoProduto.Domain.Repositories;
using CatalogoProduto.Domain.Services;
using CatalogoProduto.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogoProduto.Api.IoC
{
    public static class InjecaoDependencia
    {
        public static void AdicionarServicos(this IServiceCollection pServices)
        {
            pServices
                .AddScoped<IProdutoService, ProdutoService>()
                .AddScoped<IProdutoRepository, ProdutoRepository>()
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}