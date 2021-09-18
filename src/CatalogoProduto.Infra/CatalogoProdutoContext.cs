using System;
using System.Linq;
using CatalogoProduto.Domain.Entities;
using CatalogoProduto.Infra.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProduto.Infra
{
    public class CatalogoProdutoContext
        : DbContext
    {
        public CatalogoProdutoContext(DbContextOptions<CatalogoProdutoContext> pOptions)
            : base(pOptions)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        public void Detach<TEntity>(Func<TEntity, bool> pPredicate) where TEntity : class
        {
            var xEntities = Set<TEntity>().Local.Where(pPredicate);
            foreach (var xEntity in xEntities)
                Entry(xEntity).State = EntityState.Detached;
        }

        protected override void OnModelCreating(ModelBuilder pModelBuilder)
        {
            pModelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");
            pModelBuilder.ApplyConfiguration(new ProdutoEntityTypeConfiguration());
        }
    }
}