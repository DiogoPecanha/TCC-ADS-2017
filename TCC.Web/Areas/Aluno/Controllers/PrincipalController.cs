using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Aplicacao.Dtos;
using TCC.Aplicacao.Interfaces;
using TCC.Web.Controllers;
using TCC.Web.Models;

namespace TCC.Web.Areas.Aluno.Controllers
{
    public class PrincipalController : DefaultController {
        private readonly IUsuarioServicoAplicacao _servicoUsuario;
        private readonly IViewAlunoServicoAplicacao _servicoViewAlunoAplicacao;
        public PrincipalController(IUsuarioServicoAplicacao usuarioServicoAplicacao, IViewAlunoServicoAplicacao servicoViewAlunoAplicacao) {
            _servicoUsuario = usuarioServicoAplicacao;
            _servicoViewAlunoAplicacao = servicoViewAlunoAplicacao;
        }
        public ActionResult Index() {
            ValidaPermissao(AlunoId);
            return View();
        }

        public ActionResult MeusDados() {
            ValidaPermissao(AlunoId);

            var aluno = _servicoViewAlunoAplicacao.Todos().Single(x => x.Login == CredencialUsuario.Usuario.Login);
            var viewAluno = new AlunoModelView();
            AutoMapper.Mapper.Map(aluno, viewAluno);
            return View(viewAluno);
        }
    }
}