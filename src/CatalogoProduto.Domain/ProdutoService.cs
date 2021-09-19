using System.Threading.Tasks;
using CatalogoProduto.Domain.Core;
using CatalogoProduto.Domain.Core.Entities;
using CatalogoProduto.Domain.Core.Interfaces;

namespace CatalogoProduto.Domain
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        private readonly Notificacoes _notificacoes;

        public ProdutoService(IProdutoRepository pRepository
            , Notificacoes pNotificacoes)
        {
            _repository = pRepository;
            _notificacoes = pNotificacoes;
        }

        public async Task<Produto> AdicionarAsync(Produto pItem)
        {
            if (!pItem.EhValido())
                return _notificacoes.AdicionarErros(pItem.Erros());

            await _repository.AdicionarAsync(pItem);
            await _repository.SalvarAsync();

            return pItem;
        }
    }
}