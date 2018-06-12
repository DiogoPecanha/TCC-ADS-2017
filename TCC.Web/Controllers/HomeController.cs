using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCC.Web.Controllers {
    public class HomeController : DefaultController {

        public HomeController() {

        }

        public ActionResult Index() {
            ViewBag.Title = "Home Page";

            //if (CredencialUsuario == null) 
            //    Response.Redirect("~/");            

            return View();
        }
    }
}
