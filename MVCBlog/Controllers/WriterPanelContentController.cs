using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
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
    }
}