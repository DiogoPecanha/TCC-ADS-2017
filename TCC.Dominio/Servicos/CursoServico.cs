using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Entidades;
using TCC.Dominio.Interfaces.Repositorios;
using TCC.Dominio.Interfaces.Servicos;

namespace TCC.Dominio.Servicos {

    public class CursoServico : Servico<Curso>, ICursoServico {

        public CursoServico(ICursoRepositorio repositorio)
            : base(repositorio) {
        }
    }
}
