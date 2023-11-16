using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //dependency injection 
        private readonly ApplicationDbContext _db;

        //DbSet<Category>Categories
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;

            //List<Category> objCategoryList = _db.Categories.ToList();
            //we cannot write _db.T.ToList() like we did in category controller
            //we need to save it and then use it
            //and db.Categories == dbSet
            this.dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            //_db.Categories.Add(obj);
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            //we have the complete DB set that we have assigned here.
            //Then on the query we can apply a where condition and I can pass the filter.
            IQueryable<T> query = dbSet;

            //whatever condition we have, it will apply that on a where condition and it will have the query ready for that.
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            //Iquerable contains query against the complete dataset
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            //remove all the entitites that are passed to IEnumerable
            dbSet.RemoveRange(entities);
        }
    }
}
