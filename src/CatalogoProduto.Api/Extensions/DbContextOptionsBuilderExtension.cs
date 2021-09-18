using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CatalogoProduto.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DbContextOptionsBuilderExtension
    {
        public static DbContextOptionsBuilder UsarSqlServer(this DbContextOptionsBuilder p
            , IConfiguration pConfiguration)
        {
            return p.UseSqlServer(pConfiguration["ConnectionString"], pBuilder => pBuilder.MigrationsAssembly(typeof(Startup).Assembly.FullName));
        }
    }
}