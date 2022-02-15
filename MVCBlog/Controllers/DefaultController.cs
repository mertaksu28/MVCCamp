using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public PartialViewResult Index(int id=0)
        {
            var contentList = contentManager.GetListByHeadingId(id);
            return PartialView(contentList);
        }

        public ActionResult Headings()
        {
            var headingLists = headingManager.GetAll();
            return View(headingLists);
        }
    }
}