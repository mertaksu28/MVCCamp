using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class ErrorPageController : Controller
    {
        // GET: ErrorPage
        public ActionResult Page403()
        {
            Response.StatusCode = 403;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }

        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
    }
}