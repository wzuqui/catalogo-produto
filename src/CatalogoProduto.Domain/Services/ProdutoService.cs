using System.Threading.Tasks;
using CatalogoProduto.Domain.Entities;
using CatalogoProduto.Domain.Repositories;

namespace CatalogoProduto.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository pRepository)
        {
            _repository = pRepository;
        }

        public async Task<Produto> AdicionarAsync(Produto pItem)
        {
            await _repository.AdicionarAsync(pItem);
            await _repository.SalvarAsync();
            return pItem;
        }
    }
}