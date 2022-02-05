using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutValues = aboutManager.GetAll();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            aboutManager.Add(about);
            return RedirectToAction("Index");
        }
    }
}