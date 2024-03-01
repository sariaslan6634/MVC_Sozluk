using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }

		public ActionResult GetAllContent(string p)
        {
            if (p == null)
            {
                p = "";
            }
            var values = cm.GetList(p);
            return View(values);
		}

		public ActionResult ContentByHeading(int id)
		{
            var contentvalues = cm.GetListByHeadingID(id);
			return View(contentvalues);
		}
	}
}