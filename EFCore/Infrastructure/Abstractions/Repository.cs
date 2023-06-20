using EFCore.Domain.Abstractions;
using EFCore.Infrastructure.Context;
using EFCore.Infrastructure.Requests;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EFCore.Infrastructure.Abstractions
{
    public abstract class Repository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _applicationDbContext.Set<T>().AddAsync(entity);
                await _applicationDbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await _applicationDbContext.Set<T>().AddRangeAsync(entities);
                await _applicationDbContext.SaveChangesAsync();
                return entities;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _applicationDbContext.Set<T>().Remove(entity);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                _applicationDbContext.Set<T>().RemoveRange(entities);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                return await _applicationDbContext.Set<T>()
                    .Where(expression)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _applicationDbContext.Set<T>()
                        .AsNoTracking()
                        .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _applicationDbContext.Set<T>()
                        .Where(e => e.Id.Equals(id))
                        .FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetPageAsync(Pagination request)
        {
            try
            {
                return await _applicationDbContext.Set<T>()
                        .AsNoTracking()
                        .Skip(request.Page * request.Size)
                        .Take(request.Size)
                        .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _applicationDbContext.Set<T>().Update(entity);
                await _applicationDbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                _applicationDbContext.Set<T>().UpdateRange(entities);
                await _applicationDbContext.SaveChangesAsync();
                return entities;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}