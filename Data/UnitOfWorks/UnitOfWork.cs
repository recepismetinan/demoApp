using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Data.Context;
using Data.Repositories.Abstraction;
using Data.Repositories.Concrete;


namespace Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
         return new Repository<T>(_dbContext);
        }

        public int Save()
        {
          return _dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
           return await _dbContext.SaveChangesAsync();
        }
    }
}