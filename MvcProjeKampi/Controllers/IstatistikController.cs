using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        //Toplam kategori sayısı bulma 
        public ActionResult Index()
        {
            return View();
        }
    }
}