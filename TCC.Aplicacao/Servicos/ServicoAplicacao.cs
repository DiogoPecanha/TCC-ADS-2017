using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Aplicacao.Dtos;
using TCC.Aplicacao.Interfaces;
using TCC.Dominio.Entidades;
using TCC.Dominio.Interfaces.Servicos;

namespace TCC.Aplicacao.Servicos {
    public abstract class ServicoAplicacao<TipoDoDto, TipoDaEntidade> : IServicoAplicacao<TipoDoDto, TipoDaEntidade> where TipoDaEntidade : Entidade where TipoDoDto : Dto {
        private readonly IServico<TipoDaEntidade> _servico;

        public ServicoAplicacao(IServico<TipoDaEntidade> servico) {
            _servico = servico;
        }

        public TipoDoDto[] Todos() {
            TipoDoDto[] dtos = null;

            return Mapper.Map(_servico.Todos().ToArray(), dtos);
        }

        public TipoDoDto PorId(string id) {
            TipoDoDto dto = default(TipoDoDto);
            return Mapper.Map(_servico.PorId(id), dto);
        }

        public abstract int Salvar(TipoDoDto dto);

        public void Excluir(TipoDoDto dto) {
            ExcluirPorId(dto.Id);
        }

        public void ExcluirPorId(string id) {
            var entidade = _servico.PorId(id);
            _servico.Excluir(entidade);
        }

        public PesquisaAvancadaSaidaDto<TipoDoDto> Todos(PesquisaAvancadaDto parametrosPesquisa) {
            TipoDoDto[] dtos = null;
            var consultaDeEntidades = _servico.Todos().PesquisaAvancada(parametrosPesquisa);
            int totalRegistros = consultaDeEntidades.Count();

            if (parametrosPesquisa.PaginarResultado)
                consultaDeEntidades = consultaDeEntidades.Paginar(parametrosPesquisa);

            TipoDaEntidade[] entidades = consultaDeEntidades.ToArray();

            dtos = Mapper.Map(entidades, dtos);

            return new PesquisaAvancadaSaidaDto<TipoDoDto> { Resultado = dtos, TotalDeRegistrosSemPaginar = totalRegistros };
        }
    }
}
