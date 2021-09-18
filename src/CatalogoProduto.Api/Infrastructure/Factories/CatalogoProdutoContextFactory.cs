using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using CatalogoProduto.Api.Extensions;
using CatalogoProduto.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CatalogoProduto.Api.Infrastructure.Factories
{
    [ExcludeFromCodeCoverage]
    // ReSharper disable once UnusedType.Global
    public class CatalogoProdutoContextFactory : IDesignTimeDbContextFactory<CatalogoProdutoContext>
    {
        public CatalogoProdutoContext CreateDbContext(string[] pArgs)
        {
            var xConfig = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddEnvironmentVariables()
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                .AddCommandLine(pArgs)
                .Build();

            var xOptionsBuilder = new DbContextOptionsBuilder<CatalogoProdutoContext>().UsarSqlServer(xConfig);
            return new CatalogoProdutoContext((DbContextOptions<CatalogoProdutoContext>)xOptionsBuilder.Options);
        }
    }
}