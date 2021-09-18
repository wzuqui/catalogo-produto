using System.Diagnostics.CodeAnalysis;
using CatalogoProduto.Api.Extensions;
using CatalogoProduto.Api.Infrastructure;
using CatalogoProduto.Infra;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CatalogoProduto.Api
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] pArgs)
        {
            WebHost.CreateDefaultBuilder(pArgs)
                .UseStartup<Startup>()
                .Build()
                .MigrarDbContext<CatalogoProdutoContext>((pContext
                    , pServices) =>
                {
                    var xLogger = pServices.GetService<ILogger<CatalogoProdutoContextSeed>>();
                    new CatalogoProdutoContextSeed().SeedAsync(pContext, xLogger).Wait();
                })
                .Run();
        }
    }
}