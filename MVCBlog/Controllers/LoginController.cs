using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCBlog.Controllers
{
    [AllowAnonymous]
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
        //WriterLogin
        //Yazar giriş işlemlerini mimariye taşı
        //Ben robot değilim
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            Context context = new Context();
            var writerUserInfo = context.Writers.FirstOrDefault(w => w.WriterMail == writer.WriterMail && w.WriterPassword == writer.WriterPassword);
            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                Session["WriterMail"] = writerUserInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}