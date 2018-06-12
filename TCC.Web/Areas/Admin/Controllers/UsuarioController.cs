using MySql.Data.MySqlClient;
using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Aplicacao.Dtos;
using TCC.Aplicacao.Interfaces;
using TCC.Utilitarios;
using TCC.Web.Controllers;
using TCC.Web.Models;

namespace TCC.Web.Areas.Admin.Controllers
{
    public class UsuarioController : DefaultController {
        private readonly IUsuarioServicoAplicacao _servicoUsuario;
        private readonly IViewUsuarioPerfilServicoAplicacao _servicoUsuarioPerfilAplicacao;
        public UsuarioController(IUsuarioServicoAplicacao usuarioServicoAplicacao, IViewUsuarioPerfilServicoAplicacao servicoUsuarioPerfilAplicacao) {
            _servicoUsuario = usuarioServicoAplicacao;
            _servicoUsuarioPerfilAplicacao = servicoUsuarioPerfilAplicacao;
        }
        // GET: Admin/Usuario
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No) {
            ValidaPermissao(AdministradorId);

            return View();
        }

        public ActionResult Cadastrar() {
            ValidaPermissao(AdministradorId);
            UsuarioModelView model = new UsuarioModelView();
            model.Senha = Guid.NewGuid().ToString().Split('-')[0];
            return View(model);
        }

        [HttpPost]
        public ActionResult Cadastrar(UsuarioModelView model) {
            ValidaPermissao(AdministradorId);
            
            var senha = Criptografia.GerarHashMd5(model.Senha);
            var perfil = model.PerfisDisponiveis.Perfil.Where(x => x.Id == model.IdPerfil).First();

            UsuarioDto usuario = new UsuarioDto();
            usuario.Id = Guid.NewGuid().ToString();
            usuario.Login = model.Login;
            usuario.Senha = senha;
            usuario.Aprovado = true;
            usuario.Bloqueado = false;
            usuario.DataCriacao = DateTime.Now;
            usuario.Perfil = new PerfilDto() {
                Id = perfil.Id,
                Nome = perfil.Nome
            };
            _servicoUsuario.Salvar(usuario);

            return RedirectToAction("Index");
        }
    }
}