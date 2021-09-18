using CatalogoProduto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoProduto.Infra.EntityTypeConfigurations
{
    public class ProdutoEntityTypeConfiguration
        : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> pBuilder)
        {
            pBuilder.ToTable("Produtos");
            pBuilder.HasKey(p => p.Id);
            pBuilder.Property(p => p.Nome).HasColumnType("varchar").HasMaxLength(250);
            pBuilder.Property(p => p.Valor).HasPrecision(9, 2);
        }
    }
}