using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Web.Controllers;

namespace TCC.Web.Areas.Admin.Controllers
{
    public class PrincipalController : DefaultController {
        public PrincipalController() {
            ValidaPermissao(AdministradorId);
        }
        // GET: Admin/Home
        public ActionResult Index() {
            ValidaPermissao(AdministradorId);

            return View();
        }
    }
}