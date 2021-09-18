namespace ProdutoSolution.Domain.Entities
{
    public record Entity<TKey>(TKey Id) where TKey : struct;
}