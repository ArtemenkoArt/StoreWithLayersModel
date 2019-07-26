using Store.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Logic.Services
{
    interface IProductServise
    {
        IEnumerable<ProductLL> GetAll();
        ProductLL Get(int? id);
        void Create(ProductLL item);
        void Update(ProductLL item);
        void Delete(int? id);
    }
}
