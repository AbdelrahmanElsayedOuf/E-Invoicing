using E_Invoicing.Application.Utilities.HelperClasses;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> where T : class, IEntity, new()
    {
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] IncludeProperties);
        Task<List<T>> GetAllAsync();
        Task<PageList<T>> GetAllAsync(int pageNumber, int pageSize);
        Task<Guid> DeleteByIdAsync(Guid id);
        Task<Guid> AddAsync(T entity);
        Task<T> UpdateAsync(Guid id, T entity);
        Task<T> PatchAsync(Guid id, T entity);
        Task<PageList<T>> GetAllAsync(int pageNumber, int pageSize, params Expression<Func<T, object>>[] IncludeProperties);
    }
}
