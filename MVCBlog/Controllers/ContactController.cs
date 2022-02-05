using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator validationRules = new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = contactManager.GetAll();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetById(id);
            return View(contactValues);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}