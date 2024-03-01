using BusinessLayer.Concrate;
using BusinessLayer.ValidationRule;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
			string p = (string)Session["WriterMail"];
            var messageList = mm.GetListInbox(p);
            return View(messageList);
        }
		public ActionResult Sendbox()
		{
			string p = (string)Session["WriterMail"];
			var messageList = mm.GetListSendbox(p);
			return View(messageList);
		}
		//Gelen mesajlar
		public ActionResult GetInBoxMessageDetails(int id)
		{
			var values = mm.GetByID(id);
			return View(values);
		}
		//Gönderilen mesajlar
		public ActionResult GetSendBoxMessageDetails(int id)
		{
			var values = mm.GetByID(id);
			return View(values);
		}
		//Yeni mesaj yazma işlemi
		[HttpGet]
		public ActionResult NewMessage()
		{
			return View();
		}
		[HttpPost]
		public ActionResult NewMessage(Message p)
		{
			string sender = (string)Session["WriterMail"];
			ValidationResult results = messageValidator.Validate(p);
			if (results.IsValid)
			{
				p.SenderMail = sender;
				p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
				mm.MessageAdd(p);
				return RedirectToAction("Sendbox");
			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
		public ActionResult MessageListMenu() 
        {
            return PartialView();
        }
    }
}