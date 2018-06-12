using NHibernate.Event.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.InjecaoDeDependencias.Auditoria {
    public class PatchedDefaultFlushEventListener : DefaultFlushEventListener {

        protected override void PerformExecutions(global::NHibernate.Event.IEventSource session) {
            session.PersistenceContext.Flushing = true;

            try {
                session.ConnectionManager.FlushBeginning();
                session.ActionQueue.PrepareActions();
                session.ActionQueue.ExecuteActions();
            } finally {
                session.PersistenceContext.Flushing = false;
                session.ConnectionManager.FlushEnding();
            }
        }

    }
}