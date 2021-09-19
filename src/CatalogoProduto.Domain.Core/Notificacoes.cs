using System.Collections.Generic;
using System.Linq;

namespace CatalogoProduto.Domain.Core
{
    public class Notificacao
    {
        private readonly List<string> _erros;

        public Notificacao()
        {
            _erros = new List<string>();
        }

        public bool ExisteErros => _erros.Any();
        public IReadOnlyCollection<string> Erros => _erros;

        public dynamic AdicionarErros(IEnumerable<string> pErros)
        {
            _erros.AddRange(pErros);
            return default;
        }
    }
}