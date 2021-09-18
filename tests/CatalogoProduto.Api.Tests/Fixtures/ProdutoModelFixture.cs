using Bogus;
using CatalogoProduto.Api.Produtos;

namespace CatalogoProduto.Api.Tests.Fixtures
{
    public class ProdutoModelFixture
    {
        public static ProdutoAdicionarModel CriaProdutoAdicionarModel()
        {
            return new Faker<ProdutoAdicionarModel>("pt_BR")
                .RuleFor(p => p.Nome, p => p.Commerce.ProductName())
                .RuleFor(p => p.Valor, p => decimal.Parse(p.Commerce.Price()))
                .Generate();
        }
    }
}