using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
	[AllowAnonymous]
    public class LoginController : Controller
    {
		//Admin girişi
		// GET: Login

		WriterLoginManager wlm = new WriterLoginManager(new EfWriterLoginDal());
		AdminLoginManager alm = new AdminLoginManager(new EfAdminLoginDal());

		[HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
		public ActionResult Index(Admin p)
		{
			var adminuserinfo = alm.GetUserPassword(p.AdminUserName,p.AdminPassword);
			var adminRol = alm.GetRoles(p.AdminRole);
			if (adminuserinfo != null || adminRol !=null) 
			{
				FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
				Session["AdminUserName"] = adminuserinfo.AdminUserName;
				return RedirectToAction("Index","AdminCategory");
			}
			else
			{
				return RedirectToAction("Index");
			}
		}
		[HttpGet]
		public ActionResult WriterLogin()
		{
			return View();
		}
		[HttpPost]
		public ActionResult WriterLogin(Writer p)
		{
			var writeruserinfo = wlm.GetUserPassword(p.WriterMail, p.WriterPassword);
			if (writeruserinfo != null)
			{
				FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
				Session["WriterMail"] = writeruserinfo.WriterMail;
				return RedirectToAction("MyHeading", "WriterPanel");
			}
			else
			{
				return RedirectToAction("WriterLogin");
			}
		}
		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();
			Session.Abandon();
			return RedirectToAction("Headings","Default");
		}
	}
}