using System.Collections.Generic;
using Bogus;
using CatalogoProduto.Domain.Entities;

namespace CatalogoProduto.Domain.Tests.Fixtures
{
    public class ProdutoFixture
    {
        public static IEnumerable<Produto> CriaProdutoValido(int pQuantidade)
        {
            return new Faker<Produto>("pt_BR")
                .RuleFor(p => p.Id, p => p.IndexFaker)
                .RuleFor(p => p.Nome, p => p.Commerce.ProductName())
                .RuleFor(p => p.Valor, p => decimal.Parse(p.Commerce.Price()))
                .Generate(pQuantidade);
        }
    }
}