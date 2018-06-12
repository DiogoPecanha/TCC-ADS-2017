using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Web.Controllers;

namespace TCC.Web.Areas.Operador.Controllers
{
    public class PrincipalController : DefaultController
    {
        // GET: Operador/Principal
        public ActionResult Index() {
            ValidaPermissao(OperadorId);

            return View();
        }
    }
}