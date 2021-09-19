using Bogus;
using CatalogoProduto.Api.Produtos;
using CatalogoProduto.Domain.Core.Entities;

namespace CatalogoProduto.Api.Tests.Fixtures
{
    public class ProdutoModelFixture
    {
        public static ProdutoModel CriaProdutoModelInvalido()
        {
            return new Faker<ProdutoModel>("pt_BR")
                .RuleFor(p => p.Id, p => default)
                .RuleFor(p => p.Nome, p => p.Random.String2(Produto.NOME_TAMANHO_MAXIMO * 2))
                .RuleFor(p => p.Valor, p => decimal.Parse(p.Commerce.Price()))
                .Generate();
        }

        public static ProdutoModel CriaProdutoModelValido()
        {
            return new Faker<ProdutoModel>("pt_BR")
                .RuleFor(p => p.Id, p => default)
                .RuleFor(p => p.Nome, p => p.Commerce.ProductName())
                .RuleFor(p => p.Valor, p => decimal.Parse(p.Commerce.Price()))
                .Generate();
        }
    }
}