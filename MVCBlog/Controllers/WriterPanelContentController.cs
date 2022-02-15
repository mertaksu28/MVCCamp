using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult MyContent(string sesion)
        {
            Context context = new Context();
            sesion = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(w => w.WriterMail == sesion).Select(i => i.WriterId).FirstOrDefault();
            var contentValues = contentManager.GetAllByWriter(writerIdInfo);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.D = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            Context context = new Context();
            string email = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(w => w.WriterMail == email).Select(i => i.WriterId).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writerIdInfo;
            content.Status = true;
            contentManager.Add(content);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}