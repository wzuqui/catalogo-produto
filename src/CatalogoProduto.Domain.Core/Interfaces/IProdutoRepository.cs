using CatalogoProduto.Domain.Core.Entities;

namespace CatalogoProduto.Domain.Core.Interfaces
{
    public interface IProdutoRepository
        : IRepository<int, Produto>
    {
        
    }
}