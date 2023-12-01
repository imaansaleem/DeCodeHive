using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        //Defining attributes
        //The class inheriting thu will have to make objects of all and assign them tables
        ICategoryRepository Category { get;}
        IProductRepository Product { get; }
        ICompanyRepository Company { get; }
        void Save();

    }
}
