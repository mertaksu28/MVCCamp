using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.GetListByHeadingId(id);
            return View(contentValues);
        }
    }
}