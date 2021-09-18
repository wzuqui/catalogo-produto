namespace ProdutoSolution.Domain.Entities
{
    public record Produto(int Id
            , string Nome
            , decimal Valor)
        : Entity<int>(Id);
}