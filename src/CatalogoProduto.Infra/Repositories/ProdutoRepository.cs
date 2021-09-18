using CatalogoProduto.Domain.Entities;
using CatalogoProduto.Domain.Repositories;

namespace CatalogoProduto.Infra.Repositories
{
    public class ProdutoRepository
        : Repository<int, Produto>
            , IProdutoRepository
    {
        public ProdutoRepository(CatalogoProdutoContext pContext)
            : base(pContext)
        {
        }
    }
}