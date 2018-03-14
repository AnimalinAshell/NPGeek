using NPGeek.Web.DAL;
using NPGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NPGeek.Web.Controllers
{
    public class HomeController : Controller
    {

        IParkDAL dal;
        public HomeController(IParkDAL dal)
        {
            this.dal = dal;
        }

        // GET: Home
        public ActionResult Index()
        {
            List<ParkModel> list = dal.GetAllParks();
            return View("Index", list);
        }

        public ActionResult Detail(ParkModel model)
        {
            return View("Detail", model);
        }
    }
}