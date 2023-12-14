using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //get all categories
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter=null, string? includeProperties = null);

        //Func is a delegate type that represents a reference to a method that takes a specific number of input parameters and returns a result.
        //Func<input, Output>
        //Expression allows you to work with code as data and computed lately
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        void Add(T entity);
        void Remove(T entity);
        //Delete Multiple entities in single column
        void RemoveRange(IEnumerable<T> entities);
    }
}
