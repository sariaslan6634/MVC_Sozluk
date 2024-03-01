using BusinessLayer.Concrate;
using BusinessLayer.ValidationRule;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
		//Gelen Mesajlar
		// GET: Message

		MessageManager mm = new MessageManager(new EfMessageDal());
		MessageValidator messagevalidator = new MessageValidator();

		[Authorize]
		public ActionResult Inbox(string p)
        {
            var messageList = mm.GetListInbox(p);
            return View(messageList);
        }
		//Adminin mesaj göndermeleri gönderme
		public ActionResult Sendbox(string p)
		{
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

		//Yeni mesaj gönderme
		[HttpGet]
		public ActionResult NewMessage() 
		{
			return View();
		}
		[HttpPost]
		public ActionResult NewMessage(Message p)
		{
			ValidationResult results = messagevalidator.Validate(p);
			if (results.IsValid)
			{
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
	}
}