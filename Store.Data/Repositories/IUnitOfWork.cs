using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<ProductDL> Products { get; }
        IRepository<CategoryDL> Categories { get; }
        void Save();
    }
}
