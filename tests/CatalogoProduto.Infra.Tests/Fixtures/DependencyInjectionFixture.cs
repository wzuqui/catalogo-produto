using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogoProduto.Infra.Tests.Fixtures
{
    [ExcludeFromCodeCoverage]
    public class DependencyInjectionFixture
    {
        public readonly IServiceProvider ServiceProvider;

        public DependencyInjectionFixture()
        {
            var xServiceCollection = new ServiceCollection();
            xServiceCollection.AddDbContext<CatalogoProdutoContext>(p => p.UseSqlite($"Filename={nameof(CatalogoProdutoContext)}.db"));
            ServiceProvider = xServiceCollection.BuildServiceProvider();

            SeedContext(ServiceProvider);
        }

        private void SeedContext(IServiceProvider pServiceProvider)
        {
            var xContext = pServiceProvider.GetService<CatalogoProdutoContext>();
            Debug.Assert(xContext != null, nameof(xContext) + " != null");

            if (!xContext.Database.IsSqlite())
                return;

            xContext.Database.EnsureDeleted();
            xContext.Database.EnsureCreated();
        }
    }
}