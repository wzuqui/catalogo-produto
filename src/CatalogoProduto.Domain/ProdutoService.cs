using System.Threading.Tasks;

namespace CatalogoProduto.Domain.Produto
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