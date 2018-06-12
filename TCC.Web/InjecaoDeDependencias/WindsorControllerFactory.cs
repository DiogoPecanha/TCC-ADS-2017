using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TCC.Web.InjecaoDeDependencias {
    public class WindsorControllerFactory : DefaultControllerFactory {
        private readonly IKernel _kernel;

        public WindsorControllerFactory(IKernel kernel) {
            _kernel = kernel;
        }

        public override void ReleaseController(IController controller) {
            _kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type tipoController) {
            if (tipoController == null) {
                throw new HttpException(404, string.Format("O controller para o caminho '{0}' não pode ser encontrado.", requestContext.HttpContext.Request.Path));
            }

            return (IController)_kernel.Resolve(tipoController);
        }
    }
}