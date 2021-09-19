using CatalogoProduto.Domain.Core;

namespace CatalogoProduto.Domain.Produto
{
    public record Produto(int Id
        , string Nome
        , decimal Valor) : Entity<int>(Id)
    {
        public const int NOME_TAMANHO_MAXIMO = 200;

        public Produto() : this(default, default, default)
        {
        }
    }
}