using CatalogoProduto.Domain.Core.Entities;
using FluentValidation;

namespace CatalogoProduto.Api.Produtos
{
    public class ProdutoValidator
        : AbstractValidator<ProdutoModel>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome).NotEmpty().MaximumLength(Produto.NOME_TAMANHO_MAXIMO);
            RuleFor(p => p.Valor).NotEmpty();
        }
    }
}