using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        Context context = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            string session = (string)Session["WriterMail"];
            id = context.Writers.Where(w => w.WriterMail == session).Select(i => i.WriterId).FirstOrDefault();
            var writerValue = writerManager.GetById(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult result = validationRules.Validate(writer);
            if (result.IsValid)
            {
                writerManager.Update(writer);
                return RedirectToAction("AllHeading","WriterPanel");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult MyHeading(string session)
        {
            session = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(w => w.WriterMail == session).Select(i => i.WriterId).FirstOrDefault();
            var headingValue = headingManager.GetAllByWriter(writerIdInfo);
            return View(headingValue);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> categoryValue = (from c in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.CategoryValue = categoryValue;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string email = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(w => w.WriterMail == email).Select(i => i.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
            heading.WriterId = writerIdInfo;
            heading.Status = true;
            headingManager.Add(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
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
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.Update(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetById(id);
            headingValue.Status = false;
            headingManager.Delete(headingValue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int page = 1)
        {
            var headingAll = headingManager.GetAll().ToPagedList(page, 4);
            return View(headingAll);
        }
    }
}