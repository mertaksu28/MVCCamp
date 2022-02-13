using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();

        [Authorize]
        public ActionResult Inbox()
        {
            var messageList = messageManager.GetAllInbox();
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            var messageList = messageManager.GetAllSendbox();
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
            ValidationResult result = validationRules.Validate(message);
            if (result.IsValid)
            {
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
    }
}