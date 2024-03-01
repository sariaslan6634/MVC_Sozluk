﻿using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());

        public ActionResult Index()
        {
            var adminvalues = adminManager.GetList();
			return View(adminvalues);
		}

        [HttpGet]
        public ActionResult AddAdmin()
        { 
            return View();
		}
		[HttpPost]
		public ActionResult AddAdmin(Admin p)
		{
            adminManager.AdminAdd(p);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult EditAdmin(int id)
		{
			var adminValues = adminManager.GetByID(id);
			return View(adminValues);
		}

		[HttpPost]
		public ActionResult EditAdmin(Admin p)
		{
			adminManager.AdminUpdate(p);
			return RedirectToAction("Index");
		}
	}
}