using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Data.Repositories.Abstraction;

namespace Data.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T:BaseEntity,IBaseEntity,new();
        Task<int> SaveAsync();
        int Save();
    }
}