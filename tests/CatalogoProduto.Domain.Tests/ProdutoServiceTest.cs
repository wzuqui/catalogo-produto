using System.Linq;
using CatalogoProduto.Domain.Core;
using CatalogoProduto.Domain.Core.Entities;
using CatalogoProduto.Domain.Core.Interfaces;
using CatalogoProduto.Domain.Tests.Fixtures;
using FluentAssertions;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace CatalogoProduto.Domain.Tests
{
    public class ProdutoServiceTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ProdutoServiceTest(ITestOutputHelper pTestOutputHelper)
        {
            _testOutputHelper = pTestOutputHelper;
        }

        [Fact(DisplayName = "DADO um produto válido" +
                            " QUANDO adicionado" +
                            " ENTÃO deve persistir")]
        public async void DADO_produto_valido_QUANDO_adicionado_ENTAO_persistir()
        {
            // arrange
            const int QUANTIDADE = 2;
            var xItem = ProdutoFixture.CriaProdutoValido(QUANTIDADE).Last();
            var xRepository = new Mock<IProdutoRepository>();
            var xNotificacoes = new Notificacoes();

            xRepository.Setup(p => p.AdicionarAsync(It.IsAny<Produto>()));
            var xService = new ProdutoService(xRepository.Object, xNotificacoes);

            // act
            var xRetorno = await xService.AdicionarAsync(xItem);

            // assert
            xRepository.Verify(p => p.AdicionarAsync(xItem));
            xRepository.Verify(p => p.SalvarAsync());

            xNotificacoes.ExisteErros().Should().Be(false);
            xRetorno.Id.Should().BeGreaterThan(default);
            xRetorno.Nome.Should().NotBeNull();
        }

        [Fact(DisplayName = "DADO um produto inválido" +
                            " QUANDO executado post" +
                            " ENTÃO deve retornar null" +
                            " E conter erros")]
        public async void DADO_produto_invalido_QUANDO_executado_post_ENTAO_deve_retornar_null_E_conter_erros()
        {
            // arrange
            var xItem = ProdutoFixture.CriaProdutoInvalido();
            var xRepository = new Mock<IProdutoRepository>();
            var xNotificacoes = new Notificacoes();

            xRepository.Setup(p => p.AdicionarAsync(It.IsAny<Produto>()));
            var xService = new ProdutoService(xRepository.Object, xNotificacoes);

            // act
            var xRetorno = await xService.AdicionarAsync(xItem);
            _testOutputHelper.WriteLine(xNotificacoes.ToString());

            // assert
            xRepository.Verify(p => p.AdicionarAsync(xItem), Times.Never);
            xRepository.Verify(p => p.SalvarAsync(), Times.Never);
            xNotificacoes.ExisteErros().Should().Be(true);
            xRetorno.Should().BeNull();
        }
    }
}