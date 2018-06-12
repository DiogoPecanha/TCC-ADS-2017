using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Aplicacao.Dtos {
    public class PesquisaAvancadaDto {
        public int TamanhoPagina { get; set; }
        private bool _paginar = true;
        public bool PaginarResultado {
            get { return _paginar; }
            set { _paginar = value; }
        }

        public int InicioPagina { get; set; }
        public string ColunaOrdenacao { get; set; }
        public bool OrdemAscendente { get; set; }
        public bool EhPesquisa { get; set; }
        public Condicao CondicaoDePesquisa { get; set; }

        public class Condicao {
            public Condicao() {
                Regras = new List<Regra>();
                Agrupamentos = new List<Condicao>();
            }

            public OperadorAgrupamento OperadorDeAgrupamento { get; set; }
            public List<Regra> Regras { get; set; }
            public List<Condicao> Agrupamentos { get; set; }
        }

        public class Regra {
            public string Campo { get; set; }
            public Operador Operador { get; set; }
            public string Valor { get; set; }

            public override string ToString() {
                return string.Format("{0} -> {1} -> {2}", Campo, Operador, Valor);
            }
        }

        public enum Operador {
            [StringValue("eq")]
            Igual = 0,
            [StringValue("ne")]
            Diferente = 1,
            [StringValue("cn")]
            Contem = 2,
            [StringValue("gt")]
            MaiorQue = 3,
            [StringValue("ge")]
            MaiorOuIgual = 4,
            [StringValue("lt")]
            MenorQue = 5,
            [StringValue("le")]
            MenorOuIgual = 6,
            [StringValue("bw")]
            ComecaCom = 7,
        }

        public enum OperadorAgrupamento {
            [StringValue("AND")]
            E = 0,

            [StringValue("OR")]
            OU = 1
        }
    }

    public class StringValueAttribute : Attribute {
        public StringValueAttribute(string value) {
            this.Value = value;
        }

        public string Value { get; }
    }
}
