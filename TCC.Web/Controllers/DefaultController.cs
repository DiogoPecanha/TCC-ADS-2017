using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TCC.Web.Models;

namespace TCC.Web.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public DefaultController() {

        }


        #region Variaveis
        public const string TextoBotaoSalvarSair = "TextoBotaoSalvarSair";
        public const string CredencialUsuarioNome = "CREDENCIALUSUARIO";
        public const string MenusPerfilNome = "MENUS_PERFIL";
        public const string PaginaConsistenciaNome = "PAGINACONSISTENCIA";

        internal string AdministradorId = ConfigurationManager.AppSettings["administrador"];
        internal string AlunoId = ConfigurationManager.AppSettings["aluno"];
        internal string OperadorId = ConfigurationManager.AppSettings["operador"];
        internal string ProfessorId = ConfigurationManager.AppSettings["professor"];
        #endregion

        #region Propriedades
        public static Dictionary<string, IList<long>> Menus_Perfis_Associados {
            get { return (Dictionary<string, IList<long>>)System.Web.HttpContext.Current.Session[MenusPerfilNome]; }
            set { System.Web.HttpContext.Current.Session[MenusPerfilNome] = value; }
        }
        //private ICollection<Menu> listaMenus = null;
        public static bool PaginaConsistencia {
            get { return (bool)System.Web.HttpContext.Current.Session[PaginaConsistenciaNome]; }
            set { System.Web.HttpContext.Current.Session[PaginaConsistenciaNome] = value; }
        }
        public static CredecialModelView CredencialUsuario {
            get { return (CredecialModelView)System.Web.HttpContext.Current.Session[CredencialUsuarioNome]; }
            set { System.Web.HttpContext.Current.Session[CredencialUsuarioNome] = value; }
        }
        #endregion

        protected override void Initialize(RequestContext requestContext) {
            base.Initialize(requestContext);
            var diretorioRaiz = Request.Url.LocalPath;

            if (Menus_Perfis_Associados == null) {
                //MontarMenusPefis();
                Session[Controllers.DefaultController.PaginaConsistenciaNome] = false;
            }

            if (requestContext.HttpContext.Request.Url.AbsolutePath.ToUpper().Contains("/LOGIN") ||
                PaginaConsistencia ||
                requestContext.HttpContext.Request.Url.AbsolutePath.ToUpper().Contains("/ESQUECIMINHASENHA"))
                return;

            if (CredencialUsuario == null || CredencialUsuario.Usuario == null) {
                requestContext.HttpContext.Response.Clear();
                requestContext.HttpContext.Response.Redirect("~/Seguranca/Login?ReturnUrl=" + requestContext.HttpContext.Request.Url.PathAndQuery);
                requestContext.HttpContext.Response.End();
            } else {
                /*if (requestContext.HttpContext.Request.Url.AbsolutePath.Equals("/AtivaLine.Site/"))
                    return;*/

                /*if (!requestContext.HttpContext.Request.Url.AbsolutePath.ToUpper().Equals("/")) {
                    string urlUsuarioLogado = requestContext.HttpContext.Request.Url.AbsolutePath.ToUpper();
                    string[] arrayUrlLogado = urlUsuarioLogado.Split('/');

                    //IList<long> listaIdsPerfilLogado = CredencialUsuario.Usuario.Perfis.Id == per.IdPerfil).ToList();
                    bool acessoUrlPermitido = false;

                    //if (listaIdsPerfilLogado.Count == 0) {
                    //    if (Menus_Perfis_Associados.Where(mp => urlUsuarioLogado.Contains(mp.Key.ToUpper())).Any())
                    //        return;
                    //    else {
                    //        PaginaConsistencia = true;
                    //        IrParaPaginaConsistencia(requestContext,
                    //                                 "~/Login/ConsistirPaginaNavegada?titulo=",
                    //                                 "Página não encontrada",
                    //                                 "&texto=" + CredencialUsuario.Usuario.Login + ", a página " + requestContext.HttpContext.Request.Url.PathAndQuery +
                    //                                        ", não foi encontrada no Sistema. Dica: Verifique se a digitação na barra de endereços está correta.");
                    //    }
                    //}

                    if (!acessoUrlPermitido) {
                        PaginaConsistencia = true;
                        IrParaPaginaConsistencia(requestContext,
                                                 "~/LogUsuario/ConsistirPaginaNavegada?titulo=",
                                                 "Acesso não autorizado",
                                                 "&texto=O usuário " + CredencialUsuario.Usuario.Login + ", não possui perfil autorizado para visualizar a página " +
                                                        requestContext.HttpContext.Request.Url.PathAndQuery);
                    }

                }*/
            }
        }

        public void ValidaPermissao(string perfil) {
            if (CredencialUsuario != null && CredencialUsuario.Usuario.IdPerfil != perfil) {
                RedirecionaSemPermissao();
            } 
        }

        public ActionResult RedirecionaSemPermissao() {
            CredencialUsuario = null;
            LoginViewModel model = new LoginViewModel();
            model.MensagemLogin = "O usuário sem permissão para acessar este conteudo. Favor verificar com o supervisor responsável.";
            return RedirectToAction("login", "seguranca");

        }

        void IrParaPaginaConsistencia(RequestContext requestContext, string url, string titulo, string texto) {
            requestContext.HttpContext.Response.Clear();
            requestContext.HttpContext.Response.Redirect(url + titulo + texto);
            requestContext.HttpContext.Response.End();
        }
    }
}