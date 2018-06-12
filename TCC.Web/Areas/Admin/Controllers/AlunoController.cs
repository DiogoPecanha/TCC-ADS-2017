using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Aplicacao.Dtos;
using TCC.Aplicacao.Interfaces;
using TCC.Utilitarios;
using TCC.Web.Controllers;
using TCC.Web.Models;
using PagedList;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace TCC.Web.Areas.Admin.Controllers {
    public class AlunoController : DefaultController {
        // GET: Admin/Aluno
        private readonly IUsuarioServicoAplicacao _servicoUsuario;
        private readonly IViewAlunoServicoAplicacao _servicoViewAlunoAplicacao;
        public AlunoController(IUsuarioServicoAplicacao usuarioServicoAplicacao, IViewAlunoServicoAplicacao servicoViewAlunoAplicacao) {
            _servicoUsuario = usuarioServicoAplicacao;
            _servicoViewAlunoAplicacao = servicoViewAlunoAplicacao;
        }
        //public ActionResult Index() {
        //    return View();
        //}

        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No) {
            ValidaPermissao(AdministradorId);

            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Nome" : "";
            ViewBag.SortingDate = Sorting_Order == "DtNasc" ? "DtNasc" : "CPF";

            if (Search_Data != null) {
                Page_No = 1;
            } else {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;
            var alunos = _servicoViewAlunoAplicacao.Todos().ToArray();



            if (!String.IsNullOrEmpty(Search_Data)) {
                alunos = alunos.Where(stu => stu.Nome.ToUpper().Contains(Search_Data.ToUpper())
                    || stu.Nome.ToUpper().Contains(Search_Data.ToUpper())).ToArray();
            }
            switch (Sorting_Order) {
                case "Nome":
                    alunos = alunos.OrderByDescending(stu => stu.Nome).ToArray();
                    break;
                case "DataCriacao":
                    alunos = alunos.OrderBy(stu => stu.DataCriacao).ToArray();
                    break;
                case "CPF":
                    alunos = alunos.OrderByDescending(stu => stu.CPF).ToArray();
                    break;
                default:
                    alunos = alunos.OrderBy(stu => stu.Nome).ToArray();
                    break;
            }

            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            return View(alunos.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        public ActionResult Cadastrar() {
            ValidaPermissao(AdministradorId);
            AlunoModelView model = new AlunoModelView();            
            model.Senha = Guid.NewGuid().ToString().Split('-')[0];
            return View(model);
        }

        [HttpPost]
        public ActionResult Cadastrar(AlunoModelView model) {
            ValidaPermissao(AdministradorId);
            var user = new ViewUsuarioPerfilDto();
            AutoMapper.Mapper.Map(model, user);
            _servicoUsuario.Salvar(usuario);

            return RedirectToAction("Index");
        }
    }
}