using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Linq;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
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

        public PartialViewResult MessageListMenu(string p)
        {
            
            var noReadMessage = messageManager.GetAll();
            if (noReadMessage.Count==0)
            {
                ViewBag.NoReadMessage = noReadMessage;
            }

            var readMessage = messageManager.GetAll().Count();
            ViewBag.ReadMessage = readMessage;
            var result = contactManager.GetAll().Count();
            ViewBag.Value = result;
            var sendMail = messageManager.GetAllSendbox(p).Count();
            ViewBag.SendMail = sendMail;
            var inMail = messageManager.GetAllInbox(p).Count();
            ViewBag.InMail = inMail;
            return PartialView();
        }
    }
}