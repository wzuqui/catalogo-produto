using System.Linq;
using CatalogoProduto.Domain.Entities;
using CatalogoProduto.Domain.Repositories;
using CatalogoProduto.Domain.Services;
using CatalogoProduto.Domain.Tests.Fixtures;
using FluentAssertions;
using Moq;
using Xunit;

namespace CatalogoProduto.Domain.Tests
{
    public class ProdutoServiceTest
    {
        [Fact(DisplayName = "DADO um produto válido" +
                            " QUANDO adicionado" +
                            " ENTÃO deve persistir")]
        public async void DADO_produto_valido_QUANDO_adicionado_ENTAO_persistir()
        {
            // arrange
            const int QUANTIDADE = 2;
            var xItem = ProdutoFixture.CriaProdutoValido(QUANTIDADE).Last();
            var xRepository = new Mock<IProdutoRepository>();
            xRepository.Setup(p => p.AdicionarAsync(It.IsAny<Produto>()));
            var xService = new ProdutoService(xRepository.Object);

            // act
            var xRetorno = await xService.AdicionarAsync(xItem);

            // assert
            xRepository.Verify(p => p.AdicionarAsync(xItem));
            xRepository.Verify(p => p.SalvarAsync());
            xRetorno.Id.Should().BeGreaterThan(default);
            xRetorno.Nome.Should().NotBeNull();
        }
    }
}