using CatalogoProduto.Domain.Core.Entities;
using CatalogoProduto.Domain.Core.Interfaces;

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