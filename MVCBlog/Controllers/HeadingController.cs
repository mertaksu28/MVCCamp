using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingValue = headingManager.GetAll();
            return View(headingValue);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> categoryValue = (from c in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryId.ToString()
                                                  }).ToList();

            List<SelectListItem> writerValue = (from w in writerManager.GetAll()
                                                select new SelectListItem
                                                {
                                                    Text = w.WriterName + " " + w.WriterSurName,
                                                    Value = w.WriterId.ToString()
                                                }).ToList();

            ViewBag.WriterValue = writerValue;
            ViewBag.CategoryValue = categoryValue;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
            headingManager.Add(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> categoryValue = (from c in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.CategoryValue = categoryValue;
            var headingValue = headingManager.GetById(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            headingManager.Update(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetById(id);
            headingValue.Status = false;
            headingManager.Delete(headingValue);
            return RedirectToAction("Index");
        }
    }
}