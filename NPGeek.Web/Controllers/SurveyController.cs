using NPGeek.Web.DAL;
using NPGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NPGeek.Web.Controllers
{
    public class SurveyController : Controller
    {
        ISurveyDAL dal;
        public SurveyController(ISurveyDAL dal)
        {
            this.dal = dal;
        }

        // GET: Detail
        public ActionResult Index()
        {         
            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(SurveyModel model)
        {
            dal.SubmitSurvey(model);
            return RedirectToAction("FavoritesPage");
        }

        public ActionResult FavoritesPage()
        {
            List<SurveyModel> list = dal.GetAllParksInOrderByCount();
            return View("FavoritesPage", list); // break here coe back here after lunch
        }

    }
}