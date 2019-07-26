using AutoMapper;
using Store.Logic.Models;
using Store.Logic.Services;
using Store.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Store.Net.Controllers
{
    public class ProductController : Controller
    {
        IModelService<ProductLL> productServise;
        IModelService<CategoryLL> categoryServise;

        public ProductController(IModelService<ProductLL> productServ, IModelService<CategoryLL> categoryServ)
        {
            productServise = productServ;
            categoryServise = categoryServ;
        }

        //**
        private List<Product> GetProductListByCategoryId(int? categoryId)
        {
            List<ProductLL> productsLL = null;
            if (!categoryId.HasValue)
            {
                productsLL = productServise.GetAll().ToList();
            }
            else
            {
                productsLL.Add(productServise.Get(categoryId));
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductLL, Product>()).CreateMapper();
            var products = mapper.Map<IEnumerable<ProductLL>, List<Product>>(productsLL);
            return products;
        }

        // GET: Product
        public ActionResult Index(int? productId)
        {
            return View(GetProductListByCategoryId(productId));
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = GetProductListByCategoryId(id)[0];
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {

            productServise.Create(prod);
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
