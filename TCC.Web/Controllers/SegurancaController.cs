using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TCC.Aplicacao.Interfaces;
using TCC.Utilitarios;
using TCC.Web.Models;

namespace TCC.Web.Controllers
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
            var model = new LoginViewModel();
            return View(model);
        }

        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            CredencialUsuario = null;
            return RedirectToAction("Login", "Seguranca");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model) {
            try {
                if (ModelState.IsValid) {
                    var area = string.Empty;
                    var senha = Criptografia.GerarHashMd5(model.Senha);

                    var usuarioLogado = _servicoUsuarioPerfilAplicacao.ValidaLogin(model.Usuario, senha, model.Perfil);
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
                        FormsAuthentication.SetAuthCookie(usuarioLogado.Login, model.LembrarDados);
                        if (!CredencialUsuario.Usuario.Ativo) {
                            CredencialUsuario = null;
                            model.MensagemLogin = "O usuário referenciado ao login informado encontra-se inativo. Favor verificar com o supervisor responsável.";
                            return View("login", model);
                        } else {
                            if (!string.IsNullOrEmpty(model.Perfil)) {
                                switch (model.Perfil) {
                                    case "8b7a5555-ef5d-41a8-afd1-4a5fb6948b8d": //Administrador
                                        area = "Admin";
                                        break;
                                    case "ddd0aedd-9fcf-4f86-b3dc-7576c254d98b": //Aluno
                                        area = "Aluno";
                                        break;
                                    case "a2751561-59ee-4d91-9d6c-8adbb1ba36bd": //Operador
                                        area = "Operador";
                                        break;
                                    case "3f82df88-ece2-4089-88dd-56ad24b9f28e": //Professor
                                        area = "Professor";
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    } else {
                        model.MensagemLogin = "O usuário ou senha inválidos. Verifique!";
                        CredencialUsuario = null;
                        return View("login", model);
                    }

                    return RedirectToAction("index", "Principal", new { Area = area });
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