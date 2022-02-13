using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCBlog.Controllers
{
    public class LoginController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var adminUserInfo = adminManager.GetUserNameAndPassWord(admin.UserName, admin.Password);
            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(admin.UserName, false);
                
                Session["UserName"] = adminUserInfo.UserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}