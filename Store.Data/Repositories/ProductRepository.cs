using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class ProductRepository : IRepository<ProductDL>
    {
        private DataContext db;

        public ProductRepository(DataContext context)
        {
            this.db = context;
        }

        public ProductDL Get(int id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<ProductDL> GetAll()
        {
            return db.Products;
        }

        public IEnumerable<ProductDL> Find(Func<ProductDL, bool> predicate)
        {
            return db.Products.Where(predicate).ToList();
        }

        public void Create(ProductDL item)
        {
            db.Products.Add(item);
        }

        public void Update(ProductDL item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ProductDL product = db.Products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                db.Products.Remove(product);
            }
        }
    }
}
