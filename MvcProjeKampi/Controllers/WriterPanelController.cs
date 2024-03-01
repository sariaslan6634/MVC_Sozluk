using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRule;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
		CategoryManager cm = new CategoryManager(new EfCategoryDal());
		WriteManager wm = new WriteManager(new EfWriterDal());
		Context c = new Context();
		[HttpGet]
		public ActionResult WriterProfile(int id =0)
        {
			string p = (string)Session["WriterMail"];
			id = c.Writer.Where(x => x.WriterMail == p).Select(x => x.WriteId).FirstOrDefault();
			var writervalue = wm.GetByID(id);
			return View(writervalue);
        }
		[HttpPost]
		public ActionResult WriterProfile(Writer writer)
		{
			WriterValidator writerValidation = new WriterValidator();
			ValidationResult results = writerValidation.Validate(writer);
			if (results.IsValid)
			{
				wm.WriterUpdate(writer);
				return RedirectToAction("AllHeading","WriterPanel");
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
		public ActionResult MyHeading(string p)
		{
			p = (string)Session["WriterMail"];
			var writeridinfo = c.Writer.Where(x => x.WriterMail == p).Select(x => x.WriteId).FirstOrDefault();
			var values = hm.GetListByWriter(writeridinfo);
            return View(values);
        }
        //-------------------------
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;

            return View();
        }
		[HttpPost]
		public ActionResult NewHeading(Heading heading)
		{

			string m = (string)Session["WriterMail"];
			var writeridinfo = c.Writer.Where(x => x.WriterMail == m).Select(x => x.WriteId).FirstOrDefault();
			heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
		    heading.WriteId = writeridinfo;
			heading.HeadingStatus = true;
            hm.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
		}
        //--------------------------
		[HttpGet]
		public ActionResult EditHeading(int id)
		{
			List<SelectListItem> valuecategori = (from x in cm.GetList()
												  select new SelectListItem
												  {
													  Text = x.CategoryName,
													  Value = x.CategoryID.ToString(),
												  }).ToList();
			ViewBag.vlc = valuecategori;
			var HeadingValue = hm.GetByID(id);
			return View(HeadingValue);
		}
		[HttpPost]
		public ActionResult EditHeading(Heading p)
		{
			hm.HeadingUpdate(p);
			return RedirectToAction("MyHeading");
		}
		//----------------------------------------
		[HttpGet]
		public ActionResult DeleteHeading(int id)
		{
			var HeadingValue = hm.GetByID(id);
			HeadingValue.HeadingStatus = false;
			hm.HeadingDelete(HeadingValue);
			return RedirectToAction("MyHeading");
		}

		public ActionResult AllHeading(int p=1)
		{

			var headings = hm.GetList().ToPagedList(p, 4);
			return View(headings);
		}
	}
}