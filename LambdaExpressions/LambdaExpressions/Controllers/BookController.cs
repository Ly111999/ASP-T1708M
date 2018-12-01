using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LambdaExpressions.Context;
using LambdaExpressions.Models;

namespace LambdaExpressions.Controllers
{
    public class BookController : Controller
    {
        BookContext db = new BookContext();
        // GET: Book
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        public ActionResult ShowAfter1990()
        {
            var books = db.Books.Where(b => b.Published >= new DateTime(1990, 1, 1));
            return View(books);
        }

        public ActionResult ShowAfter2000()
        {
            var books = db.Books.Where(b => b.Published >= new DateTime(2000, 1, 1));
            return View(books);
        }
        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var book = db.Books.Find(id);
            if (book == null)
                return HttpNotFound();
            return View(book);

        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(book);
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var book = db.Books.Find(id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(book).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(book);
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Book _book)
        {
            try
            {
                Book book = new Book();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    book = db.Books.Find(id);
                    if (book == null)
                        return HttpNotFound();
                    db.Books.Remove(book);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(book);
            }
            catch
            {
                return View();
            }
        }
    }
}
