using System.Collections.Generic;
using System.Linq;

namespace CatalogoProduto.Domain.Core.Entities
{
    public abstract record Entity
    {
        private readonly List<string> _notificacoes = new();

        public bool EhValido()
        {
            Validar();
            return !_notificacoes.Any();
        }

        public IEnumerable<string> Erros()
        {
            return _notificacoes;
        }

        protected void AdicionarErro(string pMensagem)
        {
            _notificacoes.Add(pMensagem);
        }

        protected abstract void Validar();
    }

    public abstract record Entity<TKey>(TKey Id) : Entity;
}