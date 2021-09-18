using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CatalogoProduto.Infra;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;

namespace CatalogoProduto.Api.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public class CatalogoProdutoContextSeed
    {
        public async Task SeedAsync(CatalogoProdutoContext pContext
            , ILogger<CatalogoProdutoContextSeed> pLogger)
        {
            var xPolicy = CriarPolicy(pLogger, nameof(CatalogoProdutoContextSeed));
            await xPolicy.ExecuteAsync(async () =>
            {
                await using (pContext)
                {
                    await pContext.Database.MigrateAsync();
                    await pContext.SaveChangesAsync();
                }
            });
        }

        // ReSharper disable once SuggestBaseTypeForParameter
        private AsyncRetryPolicy CriarPolicy(ILogger<CatalogoProdutoContextSeed> pLogger
            , string pPrefix
            , int pRetryCount = 3)
        {
            return Policy.Handle<SqlException>().WaitAndRetryAsync(
                pRetryCount,
                // ReSharper disable once UnusedParameter.Local
                pRetry => TimeSpan.FromSeconds(5),
                (pException
                    // ReSharper disable once InconsistentNaming
                    , _
                    , pRetry
                    // ReSharper disable once InconsistentNaming
                    , _) =>
                {
                    pLogger.LogWarning(pException, "[{Prefix}] Exception {ExceptionType} com mensagem {Message} detectado na tentativa {Retry} de {Retries}"
                        , pPrefix
                        , pException.GetType().Name
                        , pException.Message
                        , pRetry
                        , pRetryCount);
                }
            );
        }
    }
}