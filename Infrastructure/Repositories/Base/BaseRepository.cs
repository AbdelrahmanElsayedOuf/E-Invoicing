using AmazonTours.Application.Utilities.HelperClasses;
using Application.Interfaces.Repositories.Base;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity, new()
    {
        private readonly AmazonToursDBContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(AmazonToursDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<Guid> AddAsync(T entity)
        {
            entity.Id = Guid.NewGuid();
            await _dbSet.AddAsync(entity);
            return entity.Id;
        }

        public async Task<Guid> DeleteByIdAsync(Guid id)
        {
            IsNullId(id);
            T entity = await _dbSet.FindAsync(id);
            if(entity != null)
            {
                entity.IsDeleted = true;
                _context.Entry(entity).State = EntityState.Deleted;
                return entity.Id;
            }
            return Guid.Empty;
        }

        private void IsNullId(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new KeyNotFoundException(nameof(id));
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.Where(e => e.IsDeleted == false).ToListAsync();
        }

        public async Task<PageList<T>> GetAllAsync(int pageNumber, int pageSize)
        {
            IQueryable<T> Query = _dbSet.Where(e => e.IsDeleted == false);
            return await PageList<T>.CreateAsync(Query, pageNumber, pageSize);
        }

        public async Task<PageList<T>> GetAllAsync(int pageNumber, int pageSize, params Expression<Func<T, object>>[] IncludeProperties)
        {
            IQueryable<T> Query = _dbSet.Where(entity => !entity.IsDeleted);
            Query = IncludeProperties.Aggregate(Query, (current, includeProperty) => current.Include(includeProperty));
            return await PageList<T>.CreateAsync(Query, pageNumber, pageSize);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            IsNullId(id);
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] IncludeProperties)
        {
            IsNullId(id);
            IQueryable<T> Query = IncludeProperties.Aggregate(_dbSet.AsQueryable(), (current, includeProperty) => current.Include(includeProperty));
            return await Query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> PatchAsync(Guid id, T entity)
        {
            IsNullId(id);
            if (id != entity.Id)
            {
                throw new ArgumentNullException(nameof(id));
            }
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<T> UpdateAsync(Guid id, T entity)
        {
            IsNullId(id);
            if(id != entity.Id)
            {
                throw new AmbiguousMatchException(nameof(id));
            }
            _dbSet.Update(entity);
            return entity;
        }
    }
}
