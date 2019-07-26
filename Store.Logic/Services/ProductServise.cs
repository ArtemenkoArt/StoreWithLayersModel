using Store.Data.Repositories;
using Store.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Logic.Services
{
    public class ProductServise : IModelService<ProductLL>
    {
        IUnitOfWork Database { get; set; }

        public ProductServise(IUnitOfWork uow)
        {
            Database = uow;
        }

        //
        public IEnumerable<ProductLL> GetAll()
        {
            var productListDL = Database.Products.GetAll();
            if (productListDL == null)
            {
                throw new ValidationException("No any Product found in database", "");
            }
            List<ProductLL> productListLL = new List<ProductLL>();
            foreach (var productDL in productListDL)
            {
                productListLL.Add(Get(productDL.CategoryId));
            }
            return productListLL;
        }

        //
        public ProductLL Get(int? id)
        {
            if (!id.HasValue)
            {
                throw new ValidationException("Product not received, field ID not filled","");
            }
            var productDL = Database.Products.Get(id.Value);
            if (productDL == null)
            {
                throw new ValidationException("Product not found in database", "");
            }
            ProductLL productLL = new ProductLL
            {
                ProductId = productDL.ProductId,
                Name = productDL.Name,
                Price = productDL.Price,
                CategoryId = productDL.CategoryId,
                ImgLink = productDL.ImgLink
            };
            return productLL;
        }

        //**
        public void Create(ProductLL productLL)
        {
            if (productLL == null)
            {
                throw new ValidationException("Product not found on Create", "");
            }

            ProductDL productDL = new ProductDL
            {
                Name = productLL.Name,
                Price = productLL.Price,
                CategoryId = productLL.CategoryId,
                ImgLink = productLL.ImgLink
            };
            Database.Products.Create(productDL);
            Database.Save();
        }

        //**
        public void Update(ProductLL productLL)
        {
            if (productLL == null)
            {
                throw new ValidationException("Product not found on Update", "");
            }
            ProductDL productDL = new ProductDL
            {
                ProductId = productLL.ProductId,
                Name = productLL.Name,
                Price = productLL.Price,
                CategoryId = productLL.CategoryId,
                ImgLink = productLL.ImgLink
            };
            Database.Products.Update(productDL);
            Database.Save();
        }

        //**
        public void Delete(int? id)
        {
            if (!id.HasValue)
            {
                throw new ValidationException("Product not found on Delete", "");
            }
            Database.Products.Delete(id.Value);
            Database.Save();
        }
    }
}
