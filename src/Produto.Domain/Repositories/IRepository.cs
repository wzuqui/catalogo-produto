using Produto.Domain.Entities;

namespace Produto.Domain.Repositories
{
    public interface IGenericRepository<TKey, TEntity>
        where TKey: struct
        where TEntity: Entity<TKey>
    {
        void AdicionarAsync()
    }
}