using CatalogoProduto.Domain.Entities;

namespace CatalogoProduto.Domain.Repositories
{
    public interface IProdutoRepository
        : IRepository<int, Produto>
    {
    }
}