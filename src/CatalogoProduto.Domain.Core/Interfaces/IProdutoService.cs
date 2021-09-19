using System.Threading.Tasks;
using CatalogoProduto.Domain.Core.Entities;

namespace CatalogoProduto.Domain.Core.Interfaces
{
    public interface IProdutoService
    {
        Task<Produto> AdicionarAsync(Produto pItem);
    }
}