using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Web.Controllers;

namespace TCC.Web.Areas.Admin.Controllers
{
    public class HomeController : DefaultController {
        // GET: Admin/Home
        public ActionResult Index() {
            return View();
        }
    }
}