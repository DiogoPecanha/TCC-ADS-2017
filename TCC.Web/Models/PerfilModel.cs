using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC.Web.Models {
    public class PerfilModel : Model {
        public string Nome { get; set; }
    }

    public class PerfisModel {
        public PerfilModel[] Perfil { get; private set; }
        public PerfisModel() {
            Perfil = new PerfilModel[] {
                new PerfilModel () { Id = "3f82df88-ece2-4089-88dd-56ad24b9f28e", Nome = "Professor" },
                new PerfilModel () { Id = "8b7a5555-ef5d-41a8-afd1-4a5fb6948b8d", Nome = "Administrador" },
                new PerfilModel () { Id = "a2751561-59ee-4d91-9d6c-8adbb1ba36bd", Nome = "Operador do Sistema" },
                new PerfilModel () { Id = "ddd0aedd-9fcf-4f86-b3dc-7576c254d98b", Nome = "Aluno" }
            };
        }
    }
}