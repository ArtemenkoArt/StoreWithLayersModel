using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    class CategoryRepository : IRepository<CategoryDL>
    {
        private DataContext db;

        public CategoryRepository(DataContext context)
        {
            this.db = context;
        }
        public CategoryDL Get(int id)
        {
            return db.Categories.Find(id);
        }

        public IEnumerable<CategoryDL> GetAll()
        {
            return db.Categories;
        }

        public void Create(CategoryDL item)
        {
            db.Categories.Add(item);
        }

        public IEnumerable<CategoryDL> Find(Func<CategoryDL, bool> predicate)
        {
            return db.Categories.Where(predicate).ToList();
        }

        public void Update(CategoryDL item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            CategoryDL category = db.Categories.FirstOrDefault(p => p.CategoryId == id);
            if (category != null)
            {
                db.Categories.Remove(category);
            }
        }
    }
}
