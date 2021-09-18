using System.Threading.Tasks;
using ProdutoSolution.Domain.Repositories;

namespace ProdutoSolution.Domain.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _repository;
        public ProdutoService(IProdutoRepository pRepository)
        {
            _repository = pRepository;
        }

        public async Task AdicionarAsync(Entities.Produto pItem)
        {
            throw new System.NotImplementedException();
        }
    }
}