using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inbox()
        {
            string email = (string)Session["WriterMail"];
            var messageList = messageManager.GetAllInbox(email);
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            string email = (string)Session["WriterMail"];
            var messageList = messageManager.GetAllSendbox(email);
            return View(messageList);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var messageValues = messageManager.GetById(id);
            return View(messageValues);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var messageValues = messageManager.GetById(id);
            return View(messageValues);
        }

        [HttpGet]
        public ActionResult AddNewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewMessage(Message message)
        {
            string senderEmail = (string)Session["WriterMail"];
            ValidationResult result = validationRules.Validate(message);
            if (result.IsValid)
            {
                message.SenderMail = senderEmail;
                message.History = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.Add(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}