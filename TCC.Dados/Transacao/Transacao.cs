using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Interfaces.Repositorios;

namespace TCC.Dados.Transacao {
    public class Transacao : ITransacao, IDisposable {

        [ThreadStatic]
        private static Transacao _atual;
        private readonly ISessionFactory _fabricaSessao;
        private ITransaction _transacao;

        public Transacao(ISessionFactory fabricaSessao) {
            _fabricaSessao = fabricaSessao;
        }

        public static Transacao Atual {
            get { return _atual; }
            set { _atual = value; }
        }

        public ISession Sessao { get; private set; }

        public void DesfazTransacao() {
            _transacao.Rollback();
            System.Diagnostics.Debug.WriteLine("Transacao desfeita   : {0} - ID: {1}", DateTime.Now, Sessao.GetSessionImplementation().SessionId);
        }

        public void Dispose() {
            System.Diagnostics.Debug.WriteLine("Sessao destruída     : {0} - ID: {1}", DateTime.Now, Sessao.GetSessionImplementation().SessionId);
            this.Dispose();

        }

        public void FinalizaTransacao() {
            _transacao.Commit();
            System.Diagnostics.Debug.WriteLine("Transacao Finalizada : {0} - ID: {1}", DateTime.Now, Sessao.GetSessionImplementation().SessionId);
            _transacao = null;
        }

        public void IniciaTransacao() {
            if (Sessao == null) {
                Sessao = _fabricaSessao.OpenSession();
                System.Diagnostics.Debug.WriteLine("Sessao criada        : {0} - ID: {1}", DateTime.Now, Sessao.GetSessionImplementation().SessionId);
            }

            _transacao = Sessao.BeginTransaction();
            System.Diagnostics.Debug.WriteLine("Transacao Iniciada   : {0} - ID: {1}", DateTime.Now, Sessao.GetSessionImplementation().SessionId);

        }
        public bool TransacoEmAndamento() {
            if (_transacao == null || _transacao.IsActive == false) {
                return false;
            }

            return true;
        }
    }
}