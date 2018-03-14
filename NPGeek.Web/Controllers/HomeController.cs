using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NPGeek.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult HomePage()
        {
            return View("HomePage");
        }

        public ActionResult DetailPage()
        {
            return View("DetailPage");
        }

        public ActionResult Survey()
        {
            return View("Survey");
        }

        public ActionResult FavoriteParks()
        {
            return View("FavoriteParks");
        }

    }
}