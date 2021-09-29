using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CatalogoProduto.Domain.Core.Entities;

namespace CatalogoProduto.Domain.Core.Interfaces
{
    public interface IRepository<in TKey, TEntity>
        where TKey : struct
        where TEntity : Entity<TKey>
    {
        Task<TEntity> AdicionarAsync(TEntity pItem);
        Task<TEntity> AtualizarAsync(TEntity pItem);
        Task<TEntity> ExcluirAsync(TKey pId);
        Task<List<TEntity>> ListarAsync(Expression<Func<TEntity, bool>> pExpression = null);
        Task<TEntity> ObterAsync(TKey pId);
        Task<int> SalvarAsync();
    }
}