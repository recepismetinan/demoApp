using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Data.Context;
using Data.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, IBaseEntity, new()
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate = null,
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (predicate != null)
                query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);


            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate = null,
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
            //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            //=> await Table.FindAsync(Guid.Parse(id));
        {
            var query = Table.AsQueryable();
            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);
            return await query.FirstOrDefaultAsync(data => data.Id == id);
        }

        ////////////////Write İşlemleri
        public async Task AddAsync(T model)
        {
            await Table.AddAsync(model);
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public async Task<T> UpdateAsync(T model)
        {
            await Task.Run(() => Table.Update(model));
            return model;
        }

        public async Task<int> SaveAsync()
            => await _dbContext.SaveChangesAsync();

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate is not null)
                return await Table.CountAsync(predicate);
            return await Table.CountAsync();
        }
    }
}
