using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TCC.Aplicacao.Interfaces;
using TCC.Dominio.Servicos;
using TCC.Web.Controllers;
using TCC.Web.Models;

namespace TCC.Web.Areas.Admin.Controllers
{
    public class SegurancaController : DefaultController {
        private readonly IUsuarioServicoAplicacao _servicoUsuario;
        private readonly IViewUsuarioPerfilServicoAplicacao _servicoUsuarioPerfilAplicacao;
        public SegurancaController(IUsuarioServicoAplicacao usuarioServicoAplicacao, IViewUsuarioPerfilServicoAplicacao servicoUsuarioPerfilAplicacao) {
            _servicoUsuario = usuarioServicoAplicacao;
            _servicoUsuarioPerfilAplicacao = servicoUsuarioPerfilAplicacao;
        }
        // GET: Admin/Seguranca
        public ActionResult Login() {
            var u = Guid.NewGuid();
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model) {
            try {
                if (ModelState.IsValid) {
                    //Ativaline.Autenticacao.AutenticacaoNegocio negocio = new Ativaline.Autenticacao.AutenticacaoNegocio();
                    var usuarioLogado = _servicoUsuarioPerfilAplicacao.ValidaLogin(model.Usuario, model.Senha, model.Perfil);
                    if (CredencialUsuario == null) {
                        CredencialUsuario = new CredecialModelView();
                    }

                    if (usuarioLogado != null) {
                        //AutoMapper.Mapper.Map(usuarioLogado, CredencialUsuario.Usuario);
                        CredencialUsuario.Usuario = new UsuarioModelView();
                        CredencialUsuario.Usuario.Aprovado = usuarioLogado.Aprovado;
                        CredencialUsuario.Usuario.Ativo = usuarioLogado.Ativo;
                        CredencialUsuario.Usuario.Bloqueado = usuarioLogado.Bloqueado;
                        CredencialUsuario.Usuario.DataCriacao = usuarioLogado.DataCriacao;
                        CredencialUsuario.Usuario.Id = usuarioLogado.Id;
                        CredencialUsuario.Usuario.Login = usuarioLogado.Login;
                        CredencialUsuario.Usuario.Senha = "";//model.Senha;
                        CredencialUsuario.Usuario.IdPerfil = usuarioLogado.IdPerfil;
                        CredencialUsuario.Usuario.PerfilNome = usuarioLogado.NomePerfil;
                        FormsAuthentication.SetAuthCookie(usuarioLogado.Login, true);
                        if (!CredencialUsuario.Usuario.Ativo) {
                            CredencialUsuario = null;
                            model.MensagemLogin = "O usuário referenciado ao login informado encontra-se inativo. Favor verificar com o supervisor responsável.";
                            return View("login", model);
                        } else {
                            //using (var contextoMotor = new motorContext()) {
                            //    CredencialUsuario.Configuracoes = contextoMotor.configuracoes.Where(x => x.IdUsuario == CredencialUsuario.Usuario.IdUsuario).ToArray();
                            //}
                        }
                    } else {
                        model.MensagemLogin = "O usuário ou senha inválidos. Verifique!";
                        CredencialUsuario = null;
                        return View("~/Views/Admin/Seguranca/login.cshtml", model);
                    }

                    return RedirectToAction("index", "PrincipalAdm");
                }
            } catch (Exception ex) {
                model.MensagemLogin = ex.Message;
                CredencialUsuario = null;
                return View("login", model);
            }

            /*if (model == null || string.IsNullOrEmpty(model.Usuario) || string.IsNullOrEmpty(model.Senha)) {
                model = new Models.LoginModelView();
                model.MensagemLogin = "Usuário e senha são obrigatórios";
            }*/

            return View("login", model);
        }
    }
}