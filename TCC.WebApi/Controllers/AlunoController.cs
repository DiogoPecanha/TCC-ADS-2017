using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCC.Aplicacao.Dtos;
using TCC.Aplicacao.Interfaces;

namespace TCC.WebApi.Controllers
{
    [Authorize]
    public class AlunoController : ApiController {
        //private readonly IUsuarioServicoAplicacao _servicoUsuario;
        //private readonly IViewAlunoServicoAplicacao _servicoViewAlunoAplicacao;

        //public AlunoController(IUsuarioServicoAplicacao usuarioServicoAplicacao, IViewAlunoServicoAplicacao servicoViewAlunoAplicacao) {
        //    _servicoUsuario = usuarioServicoAplicacao;
        //    _servicoViewAlunoAplicacao = servicoViewAlunoAplicacao;
        //}
        // GET: api/Aluno
        public IEnumerable<ViewAlunoDto> Get() {
            var lista = new List<ViewAlunoDto>();
            var conexao = ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ConnectionString;
            var consulta = @"SELECT a.IdAluno,
                                    a.Matricula,
                                    a.Ativo,
                                    a.Nome,
                                    a.Foto,
                                    a.DtNasc,
                                    a.EmailInstitucional,
                                    a.Sexo,
                                    a.NaturalidadeCidade,
                                    a.NaturalidadeUF,
                                    a.Nacionalidade,
                                    a.EstCivil,
                                    a.IdNum,
                                    a.IdExp,
                                    a.IdUF,
                                    a.IdDataEmissao,
                                    a.CPF,
                                    a.ResEndereco,
                                    a.ResBairro,
                                    a.ResCidade,
                                    a.ResEstado,
                                    a.ResUF,
                                    a.ResCEP,
                                    a.ResTel,
                                    a.EMailPessoal,
                                    a.TelCelular,
                                    a.NomePai,
                                    a.NomeMae,
                                    a.TelTrabalho
                            FROM ViewAluno a;";
            MySqlConnection con = new MySqlConnection(conexao);
            MySqlCommand cmd = new MySqlCommand(consulta, con);

            try {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.HasRows) {
                    while (reader.Read()) {
                        var aluno = new ViewAlunoDto();
                        aluno.Id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        aluno.Matricula = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        aluno.Ativo = reader.IsDBNull(2) ? false : reader.GetBoolean(2);
                        aluno.Nome = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        aluno.Foto = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        aluno.DtNasc = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                        aluno.EmailInstitucional = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        aluno.Sexo = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        aluno.NaturalidadeCidade = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        aluno.NaturalidadeUF = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        aluno.Nacionalidade = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        aluno.EstCivil = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        aluno.IdNum = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                        aluno.IdExp = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
                        aluno.IdUF = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
                        aluno.IdDataEmissao = reader.IsDBNull(15) ? DateTime.MinValue : reader.GetDateTime(15);
                        aluno.CPF = reader.IsDBNull(16) ? string.Empty : reader.GetString(16);
                        aluno.ResEndereco = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);
                        aluno.ResBairro = reader.IsDBNull(18) ? string.Empty : reader.GetString(18);
                        aluno.ResCidade = reader.IsDBNull(19) ? string.Empty : reader.GetString(19);
                        aluno.ResEstado = reader.IsDBNull(20) ? string.Empty : reader.GetString(20);
                        aluno.ResUF = reader.IsDBNull(21) ? string.Empty : reader.GetString(21);
                        aluno.ResCEP = reader.IsDBNull(22) ? 0 : reader.GetInt32(22);
                        aluno.ResTel = reader.IsDBNull(23) ? string.Empty : reader.GetString(23);
                        aluno.EMailPessoal = reader.IsDBNull(24) ? string.Empty : reader.GetString(24);
                        aluno.TelCelular = reader.IsDBNull(25) ? string.Empty : reader.GetString(25);
                        aluno.NomePai = reader.IsDBNull(26) ? string.Empty : reader.GetString(26);
                        aluno.NomeMae = reader.IsDBNull(27) ? string.Empty : reader.GetString(27);
                        aluno.TelTrabalho = reader.IsDBNull(28) ? string.Empty : reader.GetString(28);
                        lista.Add(aluno);
                    }
                    reader.NextResult();
                }
                reader.Close();
            } catch (Exception ex) {

            } finally {
                if (con.State == System.Data.ConnectionState.Open) {
                    con.Close();
                }
            }
            return lista;
        }

        // GET: api/Aluno/5
        public ViewAlunoDto Get(string id)
        {
            return new ViewAlunoDto() {
                Aprovado = true,
                Ativo = true,
                Bloqueado = false,
                CPF = "01496171608",
                DataCriacao = DateTime.Now,
                DtNasc = DateTime.Now.AddYears(-30),
                EstCivil = "Casado(a)",
                Nacionalidade = "Brasileira",
                Matricula = Guid.NewGuid().ToString().Split('-')[0],
                Nome = "Diogo Vinicius" };
        }

        // POST: api/Aluno
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Aluno/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Aluno/5
        //public void Delete(int id)
        //{
        //}
    }
}
