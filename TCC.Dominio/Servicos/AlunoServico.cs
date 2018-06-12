using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Entidades;
using TCC.Dominio.Interfaces.Repositorios;
using TCC.Dominio.Interfaces.Servicos;

namespace TCC.Dominio.Servicos {
    public class AlunoServico : Servico<Aluno>, IAlunoServico {

        public AlunoServico(IAlunoRepositorio repositorio)
            : base(repositorio) {
        }
    }
}
