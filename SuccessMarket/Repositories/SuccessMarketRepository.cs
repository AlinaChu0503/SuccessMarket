using Microsoft.EntityFrameworkCore;
using SuccessMarket.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuccessMarket.Repositories
{
    public class SuccessMarketRepository : ISuccessMarketRepository
    {
        private readonly NorthWindContext _northWindCtx;
        public DbContext NorthWindCtx { get => _northWindCtx; }

        public SuccessMarketRepository()
        {
            _northWindCtx = new NorthWindContext();
        }

        public void SaveChanges()
        {
            _northWindCtx.SaveChanges();
        }

        public void Create<T>(T value) where T : class
        {
            _northWindCtx.Entry(value).State = EntityState.Added;
        }
        public void Update<T>(T value) where T : class
        {
            _northWindCtx.Entry(value).State = EntityState.Modified;
        }

        public void Delete<T>(T value) where T : class
        {
            _northWindCtx.Entry(value).State = EntityState.Deleted;
        }

        public void DeleteAll<T>(IEnumerable<T> list) where T : class
        {
            _northWindCtx.Set<T>().RemoveRange(list);
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return _northWindCtx.Set<T>();
        }
    }
}
