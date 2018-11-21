using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LINQwithMVC5.Context;
using LINQwithMVC5.Models;

namespace LINQwithMVC5.Controllers
{
    public class ProductFruitController : Controller
    {
        MyProductContext db = new MyProductContext();
        // GET: ProductFruit
        public ActionResult Index()
        {
            return View(db.ProductFruits.ToList());
        }

        public ActionResult OrderByName()
        {
            var products = from p in db.ProductFruits
                           orderby p.Name ascending
                           select p;
            return View(products);
        }

        public ActionResult OrderByPrice()
        {
            var products = from p in db.ProductFruits
                           orderby p.Price ascending
                           select p;
            return View(products);
        }

        // GET: ProductFruit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = db.ProductFruits.Find(id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        }

        // GET: ProductFruit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductFruit/Create
        [HttpPost]
        public ActionResult Create(ProductFruit product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ProductFruits.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductFruit/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = db.ProductFruits.Find(id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        }

        // POST: ProductFruit/Edit/5
        [HttpPost]
        public ActionResult Edit( ProductFruit product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductFruit/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = db.ProductFruits.Find(id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        }

        // POST: ProductFruit/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, ProductFruit prod)
        {
            try
            {
                ProductFruit product = new ProductFruit();
                if (!ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    product = db.ProductFruits.Find(id);
                    if (product == null)
                        return HttpNotFound();
                    db.ProductFruits.Remove(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(product);
            }
            catch
            {
                return View();
            }
        }
    }
}
