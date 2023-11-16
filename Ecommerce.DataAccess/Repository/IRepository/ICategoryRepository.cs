using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    //We need our category to implement that repository.
    // when it implements the repository, we know what is the class on which we want the implementation for this repository.
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
    }
}
