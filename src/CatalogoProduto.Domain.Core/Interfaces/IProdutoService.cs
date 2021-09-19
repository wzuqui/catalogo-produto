using System.Threading.Tasks;

namespace CatalogoProduto.Domain.Produto
{
    public interface IProdutoService
    {
        Task<Produto> AdicionarAsync(Produto pItem);
    }
}