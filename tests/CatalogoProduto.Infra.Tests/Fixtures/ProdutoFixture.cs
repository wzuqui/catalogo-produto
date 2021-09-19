using System.Collections.Generic;
using Bogus;
using CatalogoProduto.Domain.Core.Entities;

namespace CatalogoProduto.Infra.Tests.Fixtures
{
    public class ProdutoFixture
    {
        public static List<Produto> CriaProdutoValido(int pQuantidade)
        {
            return new Faker<Produto>("pt_BR")
                .RuleFor(p => p.Id, p => default)
                .RuleFor(p => p.Nome, p => p.Commerce.ProductName())
                .RuleFor(p => p.Valor, p => decimal.Parse(p.Commerce.Price()))
                .Generate(pQuantidade);
        }
    }
}