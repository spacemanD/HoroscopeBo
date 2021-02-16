using DAL.Entities.Base;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository
    {
        IEnumerable<T> GetRange<T>(bool tracking, Func<T, bool> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
            where T : BaseDto;
        
        T Get<T>(bool tracking, Func<T, bool> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
            where T : BaseDto;

        T Add<T>(T exemplar)
            where T : BaseDto;

        void AddRange<T>(IEnumerable<T> range)
           where T : BaseDto;

        void DeleteRange<T>(IEnumerable<T> range)
             where T : BaseDto;

        void Delete<T>(T exemplar)
            where T : BaseDto;

        void Update<T>(T exemplar)
            where T : BaseDto;

        void UpdateRange<T>(IEnumerable<T> range)
            where T : BaseDto;

        Task<IEnumerable<T>> GetRangeAsync<T>(bool tracking, Func<T, bool> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
            where T : BaseDto;

        Task<T> GetAsync<T>(bool tracking, Func<T, bool> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
            where T : BaseDto;

        Task<T> AddAsync<T>(T exemplar)
            where T : BaseDto;

        Task AddRangeAsync<T>(IEnumerable<T> range)
            where T : BaseDto;

        Task DeleteRangeAsync<T>(IEnumerable<T> range)
            where T : BaseDto;

        Task DeleteAsync<T>(T exemplar)
            where T : BaseDto;

        Task UpdateAsync<T>(T exemplar)
            where T : BaseDto;

        Task UpdateRangeAsync<T>(IEnumerable<T> exemplars)
            where T : BaseDto;
    }
}
