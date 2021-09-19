namespace CatalogoProduto.Domain.Core
{
    public abstract record Entity<TKey>(TKey Id)
    {
    }
}