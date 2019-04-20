using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using T4Trip_end.Models;

namespace T4Trip_end.Controllers
{
    public class HomeController : Controller
    {
        private T4TContext db = new T4TContext();

        public ActionResult Index(string searching , string Address)
        {
            return View(db.Houses.Include(mmn => mmn.Location).Where(x => x.Location.NameCity.Contains(searching) && x.Address.Contains(Address) || searching == null).ToList());

            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}