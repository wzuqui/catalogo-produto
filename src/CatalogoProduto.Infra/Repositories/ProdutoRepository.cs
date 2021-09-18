using CatalogoProduto.Domain.Entities;
using CatalogoProduto.Domain.Repositories;

namespace CatalogoProduto.Infra.Repositories
{
    public class ProdutoRepositoryCrud
        : RepositoryCrud<int, Produto>
            , IProdutoRepository
    {
        public ProdutoRepositoryCrud(CatalogoProdutoContext pContext)
            : base(pContext)
        {
        }
    }
}