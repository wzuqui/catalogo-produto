using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace CatalogoProduto.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DbContextOptionsBuilderExtension
    {
        public static DbContextOptionsBuilder UsarSqlServer(this DbContextOptionsBuilder p
            , IConfiguration pConfiguration)
        {
            var xConnectionString = pConfiguration["ConnectionString"];

            if (xConnectionString != null)
                return p.UseSqlServer(pConfiguration["ConnectionString"], pBuilder => pBuilder.MigrationsAssembly(typeof(Startup).Assembly.FullName));

            const string MESSAGE = "ConnectionString não configurada, para verificar como configurar leia o README.md";
            Log.Logger.Error(MESSAGE);
            Environment.Exit(-1);
            return null;
        }
    }
}