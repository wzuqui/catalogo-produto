using System.Net.Http.Json;
using CatalogoProduto.Api.Tests.Fixtures;
using CatalogoProduto.Api.Tests.Setup;
using FluentAssertions;
using Xunit;

namespace CatalogoProduto.Api.Tests
{
    public class ProdutoControllerTest
        : TestBase
    {
        public ProdutoControllerTest(CustomWebApplicationFactory pFactory)
            : base(pFactory)
        {
        }

        [Fact(DisplayName = "DADO um produto válido" +
                            " QUANDO executado post" +
                            " ENTÃO deve retornar 201")]
        public async void DADO_produto_valido_QUANDO_executado_post_ENTAO_deve_retornar_201()
        {
            // arrange
            var xHttpClient = CriarHttpClient();
            var xModel = ProdutoModelFixture.CriaProdutoAdicionarModel();

            // act
            var xResponse = await xHttpClient.PostAsJsonAsync("/produtos", xModel);

            // assert
            xResponse.EnsureSuccessStatusCode();
            xResponse.Content.Headers.ContentType?.ToString().Should().Be("application/json; charset=utf-8");
        }
    }
}