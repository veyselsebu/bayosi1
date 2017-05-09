using bayosi.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bayosi.Controllers
{
    public class HomeController : baseController
    {

     
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ERR()
        {
            return View();
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