using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoProduto.Domain.Core
{
    public record Notificacoes
    {
        private readonly List<string> _erros;

        public Notificacoes()
        {
            _erros = new List<string>();
        }

        public bool ExisteErros() => _erros.Any();
        public IEnumerable<string> Erros() => _erros;

        public dynamic AdicionarErros(IEnumerable<string> pErros)
        {
            _erros.AddRange(pErros);
            return null;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _erros);
        }
    }
}