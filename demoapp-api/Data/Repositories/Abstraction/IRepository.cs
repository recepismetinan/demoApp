using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entity.Entities;

namespace Data.Repositories.Abstraction
{
    public interface IRepository<T> where T : BaseEntity, IBaseEntity ,new()
    {
        ////Read İşlemleri////
        //Tüm veriler
        Task<List<T>> GetAll(Expression<Func<T,bool>>predicate=null,params Expression<Func<T, object>>[] includeProperties);
        //Şarta uyan verileri çek
        Task<T> GetAsync(Expression<Func<T,bool>>predicate=null,params Expression<Func<T, object>>[] includeProperties);
        //Şartlı tek veri
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        //id ye göre alma
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);


        ////Write İşlemleri////

        //Ekleme
        Task AddAsync(T model);
        //Birden fazla veri/list ekleme
        Task<bool> AddRangeAsync(List<T> datas);
        //veriyi silme
        Task DeleteAsync(T entity);
        //belli verileri/listleri silme
        bool RemoveRange(List<T> datas);
        //verilen id silme
        //güncelleme işlemleri
        Task<T> UpdateAsync(T model);
        //kaydetme
        Task<int> SaveAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
    }
}