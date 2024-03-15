using PIZZERIA_DA_GIGI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIZZERIA_DA_GIGI.Controllers
{
    public class HomeController : Controller
    {
        DBContext db = new DBContext(); 
        
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            

            return View();
        }
    }
}
