using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository.IRepository;
using DataAcess.Data;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);

        }

        //public T Get(Expression<Func<T, bool>> filter )
        //{
        //    throw new NotImplementedException();
        //}

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> Query = dbSet;
            Query = Query.Where(filter);
            return Query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> Query = dbSet;
            return Query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
           }
}
