using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CatalogoProduto.Domain.Core.Entities;
using CatalogoProduto.Domain.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProduto.Infra.Repositories
{
    public abstract class Repository<TKey, TEntity>
        : IRepository<TKey, TEntity>
        where TKey : struct
        where TEntity : Entity<TKey>
    {
        private readonly CatalogoProdutoContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IQueryable<TEntity> _queryableReadOnly;

        protected Repository(CatalogoProdutoContext pContext)
        {
            _context = pContext;
            _dbSet = pContext.Set<TEntity>();
            _queryableReadOnly = _dbSet.AsNoTracking();
        }

        public async Task<TEntity> AdicionarAsync(TEntity pItem)
        {
            await _dbSet.AddAsync(pItem);
            return pItem;
        }

        public async Task<TEntity> AtualizarAsync(TEntity pItem)
        {
            if (!await _queryableReadOnly.AnyAsync(p => p.Id.Equals(pItem)))
                return null;

            _context.Detach<TEntity>(p => p.Id.Equals(pItem.Id));
            _context.Update(pItem);

            return pItem;
        }

        public async Task<TEntity> ExcluirAsync(TKey pId)
        {
            var xItem = await _dbSet.FirstOrDefaultAsync(p => p.Id.Equals(pId));

            if (xItem != null)
                _dbSet.Remove(xItem);

            return xItem;
        }

        public async Task<List<TEntity>> ListarAsync(Expression<Func<TEntity, bool>> pExpression)
        {
            var xRetorno = pExpression == null
                ? _queryableReadOnly.ToListAsync()
                : _queryableReadOnly.Where(pExpression).ToListAsync();

            return await xRetorno;
        }

        public async Task<TEntity> ObterAsync(TKey pId)
        {
            return await _queryableReadOnly.FirstOrDefaultAsync(p => p.Id.Equals(pId));
        }

        public async Task<int> SalvarAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}