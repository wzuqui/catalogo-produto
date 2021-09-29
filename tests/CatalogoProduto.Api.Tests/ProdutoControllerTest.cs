using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using CatalogoProduto.Api.Produtos;
using CatalogoProduto.Api.Tests.Fixtures;
using CatalogoProduto.Api.Tests.Setup;
using CatalogoProduto.Domain.Core.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
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

        [Fact(DisplayName = "DADO uma controller de produtos" +
                            " E produtos já previamente adicionados" +
                            " QUANDO executado o método GET sem parâmetros" +
                            " DEVE retornar uma lista")]
        public async void DADO_controller_produtos_E_produtos_adicionados_QUANDO_executado_DEVE_retornar_lista()
        {
            // arrange
            var xHttpClient = CriarHttpClient();
            var xProduto1 = ProdutoModelFixture.CriaProdutoModelValido();
            var xProduto2 = ProdutoModelFixture.CriaProdutoModelValido();

            // act
            await xHttpClient.PostAsJsonAsync("/produtos", xProduto1);
            await xHttpClient.PostAsJsonAsync("/produtos", xProduto2);
            var xResponse = await xHttpClient.GetFromJsonAsync<List<ProdutoModel>>("/produtos");

            // assert
            xResponse.Should().NotBeNull();
            xResponse.Should().HaveCountGreaterThan(1);
        }

        [Fact(DisplayName = "DADO um produto inválido" +
                            " QUANDO executado post" +
                            " ENTÃO deve retornar" + nameof(StatusCodes.Status400BadRequest))]
        public async void DADO_produto_invalido_QUANDO_executado_post_ENTAO_deve_retornar_400()
        {
            // arrange
            var xHttpClient = CriarHttpClient();
            var xModel = ProdutoModelFixture.CriaProdutoModelInvalido();

            // act
            var xResponse = await xHttpClient.PostAsJsonAsync("/produtos", xModel);

            // assert
            xModel.Nome.Length.Should().BeGreaterThan(Produto.NOME_TAMANHO_MAXIMO);
            xResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            xResponse.Content.Headers.ContentType?.ToString().Should().Be("application/json; charset=utf-8");
        }

        [Fact(DisplayName = "DADO um produto válido" +
                            " QUANDO executado post" +
                            " ENTÃO deve retornar 201")]
        public async void DADO_produto_valido_QUANDO_executado_post_ENTAO_deve_retornar_201()
        {
            // arrange
            var xHttpClient = CriarHttpClient();
            var xModel = ProdutoModelFixture.CriaProdutoModelValido();

            // act
            var xResponse = await xHttpClient.PostAsJsonAsync("/produtos", xModel);

            // assert
            xResponse.EnsureSuccessStatusCode();
            xResponse.Content.Headers.ContentType?.ToString().Should().Be("application/json; charset=utf-8");
        }
    }
}