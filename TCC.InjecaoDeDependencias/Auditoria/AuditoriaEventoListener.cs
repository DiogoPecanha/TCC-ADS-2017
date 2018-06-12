using NHibernate;
using NHibernate.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Entidades;
using System.Threading;

namespace TCC.InjecaoDeDependencias.Auditoria {
    public class AuditoriaEventoListener : IPreUpdateEventListener, IPostInsertEventListener, IPreDeleteEventListener {

        private const string stringSemValor = "*Sem Valor*";
        private const string stringValorNulo = "*Valor Nulo*";

        public bool OnPreDelete(PreDeleteEvent evento) {

            if (EhEntidadeAuditavelPreDelete(evento.Entity)) {
                string Entidade = ObterNomeEntidade(evento.Entity);
                string id = evento.Id.ToString();
                SalvarAuditoria(evento, "Id", id, stringValorNulo, Entidade, id);
            }

            return false;
        }

        public void OnPostInsert(PostInsertEvent evento) {

            if (EhEntidadeAuditavelPostInsert(evento.Entity)) {
                string Entidade = ObterNomeEntidade(evento.Entity);
                string id = evento.Id.ToString();
                SalvarAuditoria(evento, "Id", stringValorNulo, id, Entidade, id);
            }
        }

        public bool OnPreUpdate(PreUpdateEvent evento) {

            if (!EhEntidadeAuditavelPreUpdate(evento.Entity)) {
                return false;
            }

            var indiceCamposAlterados = evento.Persister.FindDirty(evento.State, evento.OldState, evento.Entity, evento.Session);

            if (indiceCamposAlterados == null) {
                return false;
            }

            foreach (var indice in indiceCamposAlterados) {
                string Campo = evento.Persister.PropertyNames[indice];

                if (Campo == "Versao") {
                    continue;
                }

                var valorAntigo = ObterValor(evento.OldState, indice);
                var valorNovo = ObterValor(evento.State, indice);

                if (valorAntigo == valorNovo) {
                    continue;
                }

                string Entidade = ObterNomeEntidade(evento.Entity);
                string id = evento.Id.ToString();
                SalvarAuditoria(evento, Campo, valorAntigo, valorNovo, Entidade, id);
            }

            return false;
        }

        private static void FlushSession(AbstractEvent evento) {
            var sessao = evento.Session.GetSession(EntityMode.Poco);
            sessao.Flush();
        }

        private static string ObterNomeEntidade(object entidade) {
            string Entidade = entidade.GetType().FullName;

            if (Entidade.Contains("Proxy")) {
                Entidade = entidade.GetType().BaseType.FullName;
            }

            return Entidade;
        }

        private static bool EhEntidadeAuditavelPreDelete(object entidade) {
            return entidade is Curso;
        }

        private static bool EhEntidadeAuditavelPostInsert(object entidade) {
            return entidade is Curso;
        }

        private static bool EhEntidadeAuditavelPreUpdate(object entidade) {
            return entidade is Curso;
        }

        private static void SalvarAuditoria(AbstractEvent evento, string campo, string valorAntigo, string valorNovo, string entidade, string id) {
            var sessao = evento.Session.GetSession(EntityMode.Poco);
            entidade = entidade.Replace("TCC.Dominio.", "");

            sessao.Save(new TCC.Dominio.Entidades.Auditoria {
                Entidade = entidade,
                Campo = campo,
                ValorAntigo = valorAntigo,
                ValorNovo = valorNovo,
                Login = System.Threading.Thread.CurrentPrincipal.Identity.Name,
                Chave = id,
                Data = DateTime.Now
            });

            sessao.Flush();
        }

        private static string ObterValor(object[] stateArray, int posicao) {
            var valor = stateArray[posicao];

            if (valor == null) {
                return stringValorNulo;
            } else {
                if (valor.ToString() == string.Empty) {
                    return stringSemValor;
                } else {
                    if (valor is Entidade) {
                        return ObterId(valor);
                    } else {
                        return valor.ToString();
                    }
                }
            }
        }

        private static string ObterId(object valor) {
            var propriedadeId = valor.GetType().GetProperty("Id");

            if (propriedadeId == null) {
                return null;
            } else {
                return propriedadeId.GetValue(valor, null).ToString();
            }
        }

        public Task<bool> OnPreUpdateAsync(PreUpdateEvent @event, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }

        public Task OnPostInsertAsync(PostInsertEvent @event, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }

        public Task<bool> OnPreDeleteAsync(PreDeleteEvent @event, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}
