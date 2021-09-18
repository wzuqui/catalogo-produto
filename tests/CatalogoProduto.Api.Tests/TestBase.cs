using System;
using System.Net.Http;
using CatalogoProduto.Api.Tests.Setup;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CatalogoProduto.Api.Tests
{
    public abstract class TestBase
        : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly WebApplicationFactory<StartupTest> _factory;

        protected TestBase(CustomWebApplicationFactory pFactory)
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");

            _factory = pFactory.WithWebHostBuilder(pBuilder =>
            {
                pBuilder.UseSolutionRelativeContentRoot(string.Empty);
                pBuilder.ConfigureTestServices(pServices => { pServices.AddMvc().AddApplicationPart(typeof(Startup).Assembly); });
            });
        }

        protected HttpClient CriarHttpClient()
        {
            return _factory.CreateClient();
        }
    }
}