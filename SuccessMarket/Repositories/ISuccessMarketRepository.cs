using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace SuccessMarket.Repositories
{
    public interface ISuccessMarketRepository
    {
        DbContext NorthWindCtx { get; }
        void Create<T>(T value) where T : class;
        void Delete<T>(T value) where T : class;
        void DeleteAll<T>(IEnumerable<T> list) where T : class;
        IQueryable<T> GetAll<T>() where T : class;
        void SaveChanges();
        void Update<T>(T value) where T : class;
    }
}