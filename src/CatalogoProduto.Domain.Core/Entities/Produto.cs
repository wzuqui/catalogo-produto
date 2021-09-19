
namespace CatalogoProduto.Domain.Core.Entities
{
    public record Produto(int Id
        , string Nome
        , decimal Valor) : Entity<int>(Id)
    {
        public const int NOME_TAMANHO_MAXIMO = 200;

        public Produto() : this(default, default, default)
        {
        }

        protected override void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
                AdicionarErro("Nome não pode ser vazio");
            if (Nome.Length > NOME_TAMANHO_MAXIMO)
                AdicionarErro($"Nome não deve conter mais que {NOME_TAMANHO_MAXIMO} caracteres");
            if (Valor <= 0)
                AdicionarErro("Valor deve ser maior que 0");
        }
    }
}