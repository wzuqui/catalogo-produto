using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CatalogoProduto.Domain.Core
{
    public interface IRepository<in TKey, TEntity>
        where TKey : struct
        where TEntity : Entity<TKey>
    {
        Task<TEntity> AdicionarAsync(TEntity pItem);
        Task<TEntity> AtualizarAsync(TEntity pItem);
        Task<TEntity> ExcluirAsync(TKey pId);
        IQueryable<TEntity> ListarAsync(Expression<Func<TEntity, bool>> pExpression);
        Task<TEntity> ObterAsync(TKey pId);
        Task<int> SalvarAsync();
    }
}