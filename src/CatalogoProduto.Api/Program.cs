using System.Diagnostics.CodeAnalysis;
using CatalogoProduto.Api.Extensions;
using CatalogoProduto.Api.Infrastructure;
using CatalogoProduto.Infra;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CatalogoProduto.Api
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] pArgs)
        {
            CreateHostBuilder(pArgs).Build()
                .MigrarDbContext<CatalogoProdutoContext>((pContext
                    , pServices) =>
                {
                    var xLogger = pServices.GetService<ILogger<CatalogoProdutoContextSeed>>();
                    new CatalogoProdutoContextSeed().SeedAsync(pContext, xLogger).Wait();
                })
                .Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] pArgs)
        {
            return Host.CreateDefaultBuilder(pArgs)
                .ConfigureWebHostDefaults(p => { p.UseStartup<Startup>(); })
                .UseSerilog((pBuilder
                    , pConfiguration) =>
                {
                    pConfiguration.ReadFrom.Configuration(pBuilder.Configuration);
                });
        }
    }
}