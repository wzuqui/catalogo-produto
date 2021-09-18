namespace CatalogoProduto.Domain.Entities
{
    public record Produto(int Id
        , string Nome
        , decimal Valor) : Entity<int>(Id)
    {
        // ReSharper disable once UnusedMember.Global
        public Produto() : this(default, default, default)
        {
        }
    }
}