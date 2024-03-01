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
    public class WriterController : Controller
    {
        WriteManager wm = new WriteManager(new EfWriterDal());
		WriterValidator writerValidation = new WriterValidator();
		// GET: Writer
		public ActionResult Index()
        {
            var WriterValues = wm.GetList();
            return View(WriterValues);
        }


        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            ValidationResult results = writerValidation.Validate(p);
            if (results.IsValid)
            {
                wm.WriterAdd(p);
                return RedirectToAction("Index");
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


        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerValue = wm.GetByID(id);
            return View(writerValue);
        }
		[HttpPost]
		public ActionResult EditWriter(Writer writer)
		{
			ValidationResult results = writerValidation.Validate(writer);
			if (results.IsValid)
			{
				wm.WriterUpdate(writer);
				return RedirectToAction("Index");
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