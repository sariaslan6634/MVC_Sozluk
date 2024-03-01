using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
		CategoryManager cm = new CategoryManager(new EfCategoryDal());
		WriteManager wm = new WriteManager(new EfWriterDal());
		public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }

        public ActionResult HeadingReport()
        {
			var headingvalues = hm.GetList();
			return View(headingvalues);
		}


		[HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategori = (from x in cm.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.CategoryID.ToString(),
                                                    }).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName +" "+ x.WriterSurName,
                                                    Value = x.WriteId.ToString()
                                                }).ToList();
            
            ViewBag.vlc = valuecategori;
            ViewBag.vlw = valuewriter;
			return View();
        }
		[HttpPost]
		public ActionResult AddHeading(Heading heading)
		{
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(heading);
            return RedirectToAction("Index");
		}

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
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetByID(id);
            HeadingValue.HeadingStatus = false;
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("Index");
        }
	}
}