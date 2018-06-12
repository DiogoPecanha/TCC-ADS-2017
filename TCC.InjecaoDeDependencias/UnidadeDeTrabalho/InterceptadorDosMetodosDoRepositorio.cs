using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TCC.InjecaoDeDependencias.UnidadeDeTrabalho {
    public class InterceptadorDosMetodosDoRepositorio : Castle.DynamicProxy.IInterceptor {
        private readonly ISession _sessao;
        private static ITransaction _transacao;

        public InterceptadorDosMetodosDoRepositorio(ISession sessao) {
            _sessao = sessao;
        }

        public void Intercept(Castle.DynamicProxy.IInvocation invocation) {

            bool precisaDeTransacao = MetodoPrecisaDeTransacao(invocation.MethodInvocationTarget);
            bool concluirTransacao = !(_transacao != null && _transacao.IsActive);

            if (!precisaDeTransacao) {
                invocation.Proceed();
                return;
            }

            IniciaTransacao(concluirTransacao);
            try {
                System.Diagnostics.Debug.WriteLine("Sessao: {0} -> Utilizada por {1}({2})",
                       _sessao.GetSessionImplementation().SessionId,
                       string.Format("{0}->{1}", invocation.InvocationTarget, invocation.Method.Name), string.Join(", ", invocation.Arguments));

                invocation.Proceed();

            } catch (Exception) {

                DesfazTransacao();
                throw;
            }

            FinalizaTransacao(concluirTransacao);
        }

        private static bool MetodoPrecisaDeTransacao(MethodInfo metodo) {
            if (UnidadeDeTrabalhoHelper.PossuiAtributoTransacao(metodo)) {
                return true;
            }

            if (UnidadeDeTrabalhoHelper.EhUmMetodoDoRepositorio(metodo)) {
                return true;
            }

            return false;
        }

        private void IniciaTransacao(bool concluirTransacao) {
            if (concluirTransacao) {
                _transacao = _sessao.BeginTransaction();
                System.Diagnostics.Debug.WriteLine("Sessao: {0} -> Transacao iniciada!", _sessao.GetSessionImplementation().SessionId);
            }
        }

        private void FinalizaTransacao(bool concluirTransacao) {
            if (concluirTransacao) {

                if (_transacao != null && _transacao.IsActive) {
                    _transacao.Commit();
                    System.Diagnostics.Debug.WriteLine("Sessao: {0} -> Transacao concluida!", _sessao.GetSessionImplementation().SessionId);
                }
            }
        }

        private void DesfazTransacao() {
            if (_transacao != null && _transacao.IsActive) {
                _transacao.Rollback();
                System.Diagnostics.Debug.WriteLine("Sessao: {0} -> Transacao desfeita!", _sessao.GetSessionImplementation().SessionId);
            }
        }
    }
}
