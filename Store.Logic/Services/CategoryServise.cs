using Store.Data.Repositories;
using Store.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Logic.Services
{
    class CategoryServise : IModelService<CategoryLL>
    {
        IUnitOfWork Database { get; set; }

        public CategoryServise(IUnitOfWork uow)
        {
            Database = uow;
        }

        //
        public IEnumerable<CategoryLL> GetAll()
        {
            var categoryListDL = Database.Categories.GetAll();
            if (categoryListDL == null)
            {
                throw new ValidationException("No any Category found in database", "");
            }

            List<CategoryLL> categoryListLL = new List<CategoryLL>();

            foreach (var categoryDL in categoryListDL)
            {
                categoryListLL.Add(Get(categoryDL.CategoryId));
            }
            return categoryListLL;
        }

        //
        public CategoryLL Get(int? id)
        {
            if (!id.HasValue)
            {
                throw new ValidationException("Category not received, field ID not filled", "");
            }
            var categoryDL = Database.Categories.Get(id.Value);
            if (categoryDL == null)
            {
                throw new ValidationException("Category not found in database", "");
            }
            CategoryLL categoryLL = new CategoryLL
            {
                CategoryId = categoryDL.CategoryId,
                Name = categoryDL.Name,
                ImgLink = categoryDL.ImgLink
            };
            return categoryLL;
        }

        //
        public void Create(CategoryLL categoryLL)
        {
            if (categoryLL == null)
            {
                throw new ValidationException("Category not found on Create", "");
            }

            CategoryDL categoryDL = new CategoryDL
            {
                Name = categoryLL.Name,
                ImgLink = categoryLL.ImgLink
            };
            Database.Categories.Create(categoryDL);
            Database.Save();
        }

        //
        public void Update(CategoryLL categoryLL)
        {
            if (categoryLL == null)
            {
                throw new ValidationException("Category not found on Update", "");
            }

            CategoryDL categoryDL = new CategoryDL
            {
                CategoryId = categoryLL.CategoryId,
                Name = categoryLL.Name,
                ImgLink = categoryLL.ImgLink
            };
            Database.Categories.Update(categoryDL);
            Database.Save();
        }

        //
        public void Delete(int? id)
        {
            if (!id.HasValue)
            {
                throw new ValidationException("Category not found on Delete", "");
            }
            Database.Categories.Delete(id.Value);
            Database.Save();
        }
    }
}
