using CatalogoProduto.Infra.Repositories;
using CatalogoProduto.Infra.Tests.Fixtures;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CatalogoProduto.Infra.Tests
{
    public class ProdutoRepositoryTest
        : IClassFixture<DependencyInjectionFixture>
    {
        private readonly CatalogoProdutoContext _context;

        public ProdutoRepositoryTest(DependencyInjectionFixture pFixture)
        {
            var xServiceProvider = pFixture.ServiceProvider;
            _context = xServiceProvider.GetService<CatalogoProdutoContext>();
        }

        [Fact(DisplayName = "DADO um produto válido" +
                            " QUANDO adicionado" +
                            " E persistido" +
                            " ENTÃO deve retornar quantidade de linhas afetadas")]
        public async void DADO_produto_valido_QUANDO_adicionado_E_persistido_ENTAO_deve_retornar_quantidade_de_linhas_afetadas()
        {
            // arrange
            const int QUANTIDADE = 2;
            var xItens = ProdutoFixture.CriaProdutoValido(QUANTIDADE);
            var xRepository = new ProdutoRepository(_context);

            // act
            foreach (var xItem in xItens)
                await xRepository.AdicionarAsync(xItem);
            var xLinhasAfetadas = await xRepository.SalvarAsync();

            // assert
            xLinhasAfetadas.Should().Be(QUANTIDADE);
            xItens.Should()
                .NotBeEmpty()
                .And.Contain(p => p.Id > 0);
        }
    }
}