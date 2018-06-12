using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Web.Controllers;
using TCC.Web.Models;

namespace TCC.Web.Areas.Admin.Controllers
{
    public class CursoController : DefaultController  {

        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No) {
            ValidaPermissao(AdministradorId);

            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Sigla" : "";
            ViewBag.SortingDate = Sorting_Order == "Sigla" ? "Sigla" : "AreaConhecimento";


            CursoModelView[] lista = new CursoModelView[5] {
                new CursoModelView { Id = Guid.NewGuid().ToString(), AreaConhecimento  = "Ciências da Saúde", Descricao = "Curso 1", Modalidade = "Presencial", NivelEnsino = "Superior", Periodicidade = "Diário", TipoCurso = "Superior", NumeroPeriodos = "5", Sigla = "C1" },
                new CursoModelView { Id = Guid.NewGuid().ToString(), AreaConhecimento  = "Engenharias", Descricao = "Curso 2", Modalidade = "Presencial", NivelEnsino = "Superior", Periodicidade = "Diário", TipoCurso = "Superior", NumeroPeriodos = "10", Sigla = "C2" },
                new CursoModelView { Id = Guid.NewGuid().ToString(), AreaConhecimento  = "Ciências Sociais Aplicadas", Descricao = "Curso 3", Modalidade = "Presencial", NivelEnsino = "Superior", Periodicidade = "Diário", TipoCurso = "Tecnológico", NumeroPeriodos = "5", Sigla = "C3" },
                new CursoModelView { Id = Guid.NewGuid().ToString(), AreaConhecimento  = "Ciências Agrárias", Descricao = "Curso 4", Modalidade = "Presencial", NivelEnsino = "Superior", Periodicidade = "Diário", TipoCurso = "Superior", NumeroPeriodos = "5", Sigla = "C4" },
                new CursoModelView { Id = Guid.NewGuid().ToString(), AreaConhecimento  = "Ciências Biológicas", Descricao = "Curso 5", Modalidade = "EAD", NivelEnsino = "Superior", Periodicidade = "Diário", TipoCurso = "Tecnológico", NumeroPeriodos = "10", Sigla = "C5" },
            }; 
            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            return View(lista.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        public ActionResult Cadastrar() {
            ValidaPermissao(AdministradorId);
            CursoModelView model = new CursoModelView();
            return View(model);
        }

        [HttpPost]
        public ActionResult Cadastrar(CursoModelView model) {
            ValidaPermissao(AdministradorId);
            return View();
        }

        public ActionResult CadastrarDisciplina(CursoModelView model) {
            ValidaPermissao(AdministradorId);
            return View(model);
        }
    }
}