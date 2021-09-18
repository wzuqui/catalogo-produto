using System.Threading.Tasks;
using CatalogoProduto.Domain.Entities;

namespace CatalogoProduto.Domain.Services
{
    public interface IProdutoService
    {
        Task<Produto> AdicionarAsync(Produto pItem);
    }
}