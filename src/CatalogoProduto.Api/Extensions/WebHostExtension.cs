﻿using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CatalogoProduto.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class WebHostExtension
    {
        public static IWebHost MigrarDbContext<TContext>(this IWebHost pHost
            , Action<TContext, IServiceProvider> pSeeder) where TContext : DbContext
        {
            using var xScope = pHost.Services.CreateScope();
            var xServices = xScope.ServiceProvider;
            var xLogger = xServices.GetRequiredService<ILogger<TContext>>();
            var xContext = xServices.GetService<TContext>();

            try
            {
                xLogger.LogInformation("Migrando banco de dados associado ao contexto {DbContextName}", typeof(TContext).Name);
                pSeeder(xContext, xServices);
                xLogger.LogInformation("Banco de dados migrado associado ao contexto {DbContextName}", typeof(TContext).Name);
            }
            catch (Exception xException)
            {
                xLogger.LogError(xException, "Ocorreu um erro ao migrar o banco de dados usado no contexto {DbContextName}"
                    , typeof(TContext).Name);
                throw;
            }

            return pHost;
        }
    }
}