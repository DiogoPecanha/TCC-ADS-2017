using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Aplicacao.Dtos;
using TCC.Dominio.Entidades;

namespace TCC.Aplicacao.Interfaces {
    public interface IServicoAplicacao {

    }

    public interface IServicoAplicacao<TipoDoDto, TipoDaEntidade> : IServicoAplicacao where TipoDaEntidade : Entidade {
        TipoDoDto PorId(string id);    
        TipoDoDto[] Todos();
        PesquisaAvancadaSaidaDto<TipoDoDto> Todos(PesquisaAvancadaDto parametrosPesquisa);
        int Salvar(TipoDoDto dto);
        void Excluir(TipoDoDto dto);
        void ExcluirPorId(string id);
    }
}
