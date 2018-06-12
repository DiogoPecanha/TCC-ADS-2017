using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Aplicacao.Dtos;
using TCC.Dominio.Entidades;

namespace TCC.Aplicacao.Interfaces {
    public interface IUsuarioServicoAplicacao : IServicoAplicacao<UsuarioDto, Usuario> {
        
    }
}
