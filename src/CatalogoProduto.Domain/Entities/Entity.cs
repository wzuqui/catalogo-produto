namespace CatalogoProduto.Domain.Entities
{
    public abstract record Entity<TKey>(TKey Id);
}