using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using CatalogoProduto.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogoProduto.Api.Tests.Setup
{
    public class StartupTest
        : Startup
    {
        public StartupTest(IConfiguration pConfiguration)
            : base(pConfiguration)
        {
        }

        protected override void AdicionarDbContext(IServiceCollection pServices)
        {
            pServices.AddDbContext<CatalogoProdutoContext>(p => p.UseSqlite($"Filename={nameof(CatalogoProdutoContext)}.db"));
            SeedContext(pServices.BuildServiceProvider());
        }

        [ExcludeFromCodeCoverage]
        private bool EhSqlite(DbContext pDbContext)
        {
            return pDbContext.Database.IsSqlite();
        }

        private void SeedContext(IServiceProvider pServiceProvider)
        {
            var xContext = pServiceProvider.GetService<CatalogoProdutoContext>();
            Debug.Assert(xContext != null, nameof(xContext) + " != null");

            // ReSharper disable once InvertIf
            if (EhSqlite(xContext))
            {
                xContext.Database.EnsureDeleted();
                xContext.Database.EnsureCreated();
            }
        }
    }
}