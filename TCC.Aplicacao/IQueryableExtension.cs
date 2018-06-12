using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TCC.Aplicacao.Dtos;

namespace TCC.Aplicacao {
    public static class IQueryableExtension {

        public static IQueryable<Tipo> PesquisaAvancada<Tipo>(this IQueryable<Tipo> queryableDePesquisa, PesquisaAvancadaDto parametrosDaPesquisaAvancada) {
            if (parametrosDaPesquisaAvancada == null || parametrosDaPesquisaAvancada.CondicaoDePesquisa == null) {
                if (!string.IsNullOrWhiteSpace(parametrosDaPesquisaAvancada.ColunaOrdenacao)) {
                    queryableDePesquisa = OrdenarPor<Tipo>(queryableDePesquisa, parametrosDaPesquisaAvancada.ColunaOrdenacao, parametrosDaPesquisaAvancada.OrdemAscendente);
                }

                return queryableDePesquisa;
            }

            ParameterExpression parametroEntrada = Expression.Parameter(queryableDePesquisa.ElementType, "p");

            Expression expressaoLambda = CriarExpressao(parametroEntrada, parametrosDaPesquisaAvancada.CondicaoDePesquisa);
            MethodCallExpression chamadaDoMetodoWhereComExpressaoLambda = Expression.Call(typeof(Queryable), "Where", new[] { queryableDePesquisa.ElementType }, new[] { queryableDePesquisa.Expression, Expression.Lambda<Func<Tipo, bool>>(expressaoLambda, parametroEntrada) });

            queryableDePesquisa = queryableDePesquisa.Provider.CreateQuery<Tipo>(chamadaDoMetodoWhereComExpressaoLambda);

            if (!string.IsNullOrWhiteSpace(parametrosDaPesquisaAvancada.ColunaOrdenacao)) {
                queryableDePesquisa = OrdenarPor<Tipo>(queryableDePesquisa, parametrosDaPesquisaAvancada.ColunaOrdenacao, parametrosDaPesquisaAvancada.OrdemAscendente);
            }

            return queryableDePesquisa;
        }

        public static IQueryable<Tipo> OrdenarPor<Tipo>(this IQueryable<Tipo> query, string sortColumn, bool ordemAscendente) {
            string nomeDoMetodo = string.Format("OrderBy{0}", ordemAscendente ? "" : "descending");

            ParameterExpression parametroEntrada = Expression.Parameter(query.ElementType, "p");

            MemberExpression memberAccess = null;

            foreach (string nomePropriedade in sortColumn.Split('.')) {
                memberAccess = MemberExpression.Property(memberAccess ?? (parametroEntrada as Expression), nomePropriedade);
            }

            LambdaExpression orderByLambda = Expression.Lambda(memberAccess, parametroEntrada);

            MethodCallExpression resultado = Expression.Call(
                typeof(Queryable),
                nomeDoMetodo,
                new[] { query.ElementType, memberAccess.Type },
                query.Expression,
               Expression.Quote(orderByLambda));

            return query.Provider.CreateQuery<Tipo>(resultado);
        }

        public static IQueryable<Tipo> Paginar<Tipo>(this IQueryable<Tipo> query, PesquisaAvancadaDto parametros) {
            query = Queryable.Take<Tipo>(Queryable.Skip<Tipo>(query, (parametros.InicioPagina - 1) * parametros.TamanhoPagina), parametros.TamanhoPagina);
            return query;
        }

        private static Expression CombinarExpressoes(PesquisaAvancadaDto.OperadorAgrupamento groupOp, Expression expressaoEsquerda, Expression expressaoDireita) {
            Expression expression = null;

            switch (groupOp) {
                case PesquisaAvancadaDto.OperadorAgrupamento.E:
                    expression = Expression.AndAlso(expressaoEsquerda, expressaoDireita);
                    break;
                case PesquisaAvancadaDto.OperadorAgrupamento.OU:
                    expression = Expression.OrElse(expressaoEsquerda, expressaoDireita);
                    break;
            }

            return expression;
        }

        private static Expression CriarExpressao(ParameterExpression parametroEntrada, PesquisaAvancadaDto.Condicao condicoes) {
            Expression condicao = null;

            foreach (PesquisaAvancadaDto.Regra regra in condicoes.Regras) {

                if (condicao == null) {
                    condicao = CriarExpressao(parametroEntrada, regra.Campo, regra.Valor, regra.Operador);
                } else {
                    Expression novaCondicao = CriarExpressao(parametroEntrada, regra.Campo, regra.Valor, regra.Operador);
                    condicao = CombinarExpressoes(condicoes.OperadorDeAgrupamento, condicao, novaCondicao);
                }
            }

            if (condicoes.Agrupamentos != null) {
                foreach (PesquisaAvancadaDto.Condicao agrupamento in condicoes.Agrupamentos)
                    if (condicao == null) {
                        condicao = CriarExpressao(parametroEntrada, agrupamento);
                    } else {
                        condicao = CombinarExpressoes(condicoes.OperadorDeAgrupamento, condicao, CriarExpressao(parametroEntrada, agrupamento));
                    }
            }

            return condicao;
        }

        private static Expression CriarExpressao(ParameterExpression parametroEntrada, string coluna, object valor, PesquisaAvancadaDto.Operador operador) {
            MemberExpression propriedade = null;

            foreach (string nomePropriedade in coluna.Split('.')) {
                propriedade = Expression.Property(propriedade ?? (Expression)parametroEntrada, nomePropriedade);
            }

            Expression valorPropriedade;

            if (EhDoTipoNullable(propriedade.Type)) {
                valor = valor ?? string.Empty;

                valorPropriedade = CriarValorNullable(propriedade.Type, valor.ToString());
            } else {
                try {
                    valorPropriedade = Expression.Constant(Convert.ChangeType(valor, propriedade.Type));
                } catch (FormatException erro) {
                    throw new ApplicationException(string.Format("O valor \"{0}\" não é válido para o campo {1}.", valor, propriedade.Member.Name), erro);
                }
            }

            Expression condicao = null;

            switch (operador) {
                case PesquisaAvancadaDto.Operador.Igual:
                    condicao = ExpressaoComIgual(propriedade, valorPropriedade);
                    break;
                case PesquisaAvancadaDto.Operador.Diferente:
                    condicao = ExpressaoComDiferente(propriedade, valorPropriedade);
                    break;
                case PesquisaAvancadaDto.Operador.Contem:
                    condicao = Expression.Call(propriedade, typeof(string).GetMethod("Contains"), Expression.Constant(valor));
                    break;
                case PesquisaAvancadaDto.Operador.MaiorQue:
                    condicao = ExpressaoComMaiorQue(propriedade, valorPropriedade);
                    break;
                case PesquisaAvancadaDto.Operador.MaiorOuIgual:
                    condicao = ExpressaoComMaiorOuIgual(propriedade, valorPropriedade);
                    break;
                case PesquisaAvancadaDto.Operador.MenorQue:
                    condicao = ExpressaoComMenorQue(propriedade, valorPropriedade);
                    break;
                case PesquisaAvancadaDto.Operador.MenorOuIgual:
                    condicao = ExpressaoComMenorOuIgual(propriedade, valorPropriedade);
                    break;
                case PesquisaAvancadaDto.Operador.ComecaCom:
                    condicao = Expression.Call(propriedade, typeof(string).GetMethod("StartsWith"), Expression.Constant(valor));
                    break;
            }

            return condicao;
        }

        private static Expression ExpressaoComIgual(Expression e1, Expression e2) {
            if (EhDoTipoNullable(e1.Type) && !EhDoTipoNullable(e2.Type)) {
                e2 = Expression.Convert(e2, e1.Type);
            } else if (!EhDoTipoNullable(e1.Type) && EhDoTipoNullable(e2.Type)) {
                e1 = Expression.Convert(e1, e2.Type);
            }

            return Expression.Equal(e1, e2);
        }

        private static Expression ExpressaoComMaiorQue(Expression e1, Expression e2) {
            if (EhDoTipoNullable(e1.Type) && !EhDoTipoNullable(e2.Type)) {
                e2 = Expression.Convert(e2, e1.Type);
            } else if (!EhDoTipoNullable(e1.Type) && EhDoTipoNullable(e2.Type)) {
                e1 = Expression.Convert(e1, e2.Type);
            }

            return Expression.GreaterThan(e1, e2);
        }

        private static Expression ExpressaoComMaiorOuIgual(Expression e1, Expression e2) {
            if (EhDoTipoNullable(e1.Type) && !EhDoTipoNullable(e2.Type)) {
                e2 = Expression.Convert(e2, e1.Type);
            } else if (!EhDoTipoNullable(e1.Type) && EhDoTipoNullable(e2.Type)) {
                e1 = Expression.Convert(e1, e2.Type);
            }

            return Expression.GreaterThanOrEqual(e1, e2);
        }

        private static bool EhDoTipoNullable(Type tipo) {
            if (tipo.IsGenericType)
                return tipo.GetGenericTypeDefinition() == typeof(Nullable<>);
            return false;
        }

        private static Expression ExpressaoComMenorQue(Expression e1, Expression e2) {
            if (EhDoTipoNullable(e1.Type) && !EhDoTipoNullable(e2.Type)) {
                e2 = Expression.Convert(e2, e1.Type);
            } else if (!EhDoTipoNullable(e1.Type) && EhDoTipoNullable(e2.Type)) {
                e1 = Expression.Convert(e1, e2.Type);
            }

            return Expression.LessThan(e1, e2);
        }

        private static Expression ExpressaoComMenorOuIgual(Expression e1, Expression e2) {
            if (EhDoTipoNullable(e1.Type) && !EhDoTipoNullable(e2.Type)) {
                e2 = Expression.Convert(e2, e1.Type);
            } else if (!EhDoTipoNullable(e1.Type) && EhDoTipoNullable(e2.Type)) {
                e1 = Expression.Convert(e1, e2.Type);
            }

            return Expression.LessThanOrEqual(e1, e2);
        }

        private static Expression ExpressaoComDiferente(Expression e1, Expression e2) {
            if (EhDoTipoNullable(e1.Type) && !EhDoTipoNullable(e2.Type)) {
                e2 = Expression.Convert(e2, e1.Type);
            } else if (!EhDoTipoNullable(e1.Type) && EhDoTipoNullable(e2.Type)) {
                e1 = Expression.Convert(e1, e2.Type);
            }

            return Expression.NotEqual(e1, e2);
        }

        public static Expression CriarValorNullable(Type tipo, string valor) {
            if (!EhDoTipoNullable(tipo)) {
                throw new Exception("Tipo não é um Nullable válido.");
            }

            if (string.IsNullOrWhiteSpace(valor.ToString())) {
                return Expression.Convert(Expression.Constant((object)null), tipo);
            }

            if (tipo == typeof(DateTime?)) {
                return Expression.Constant(new DateTime?(DateTime.Parse(valor)));
            }

            if (tipo == typeof(int?)) {
                return Expression.Constant(new int?(int.Parse(valor)));
            }

            if (tipo == typeof(short?)) {
                return Expression.Constant(new short?(short.Parse(valor)));
            }

            if (tipo == typeof(double?)) {
                return Expression.Constant(new double?(double.Parse(valor)));
            }

            if (tipo == typeof(Decimal?)) {
                return Expression.Constant(new Decimal?(Decimal.Parse(valor)));
            }

            throw new Exception(string.Format("Tipo não implementado: {0}", (object)tipo.ToString()));
        }
    }
}
