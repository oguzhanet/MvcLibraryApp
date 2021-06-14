using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        LibraryAppDbEntities db = new LibraryAppDbEntities();
        public ActionResult Index(string books)
        {
            var results = from book in db.Books select book;
            if (!string.IsNullOrEmpty(books))
            {
                results = results.Where(x => x.BookName.Contains(books));
            }

            //var results = db.Books.ToList();
            return View(results.ToList());
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> categories = (from category in db.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = category.CategoryName,
                                              Value = category.Id.ToString()
                                          }).ToList();
            ViewBag.category = categories;

            List<SelectListItem> writers = (from writer in db.Writers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = writer.WriterName + " " + writer.WriterLastName,
                                                Value = writer.Id.ToString()
                                            }).ToList();
            ViewBag.writer = writers;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Books books)
        {
            var category = db.Categories.Where(x => x.Id == books.Categories.Id).FirstOrDefault();
            var writer = db.Writers.Where(x => x.Id == books.Writers.Id).FirstOrDefault();
            books.Categories = category;
            books.Writers = writer;
            books.Status = true;
            db.Books.Add(books);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var result = db.Books.Find(id);
            db.Books.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetById(int id)
        {
            var result = db.Books.Find(id);
            List<SelectListItem> categories = (from category in db.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = category.CategoryName,
                                                   Value = category.Id.ToString()
                                               }).ToList();
            ViewBag.category = categories;

            List<SelectListItem> writers = (from writer in db.Writers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = writer.WriterName + " " + writer.WriterLastName,
                                                Value = writer.Id.ToString()
                                            }).ToList();
            ViewBag.writer = writers;

            return View("GetById", result);
        }

        public ActionResult Update(Books books)
        {
            var result = db.Books.Find(books.Id);
            result.BookName = books.BookName;
            result.YearOfPrinting = books.YearOfPrinting;
            result.PublishingHouse = books.PublishingHouse;
            result.NumberOfPage = books.NumberOfPage;
            result.Status = true;

            var category = db.Categories.Where(x => x.Id == books.Categories.Id).FirstOrDefault();
            result.CategoryId = category.Id;

            var writer = db.Writers.Where(x => x.Id == books.Writers.Id).FirstOrDefault();
            result.WriterId = writer.Id;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}