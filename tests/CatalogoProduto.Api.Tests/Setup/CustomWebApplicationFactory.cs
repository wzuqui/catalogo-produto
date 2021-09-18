using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CatalogoProduto.Api.Tests.Setup
{
    public class CustomWebApplicationFactory : WebApplicationFactory<StartupTest>
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            return WebHost.CreateDefaultBuilder(null).UseStartup<StartupTest>();
        }
    }
}