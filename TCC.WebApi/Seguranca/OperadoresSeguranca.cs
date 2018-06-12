using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TCC.Aplicacao.Servicos;
using TCC.Dominio.Servicos;
using TCC.Utilitarios;

namespace TCC.WebApi.Seguranca {
    public class OperadoresSeguranca {
        public static bool Login(string login, string senha) {
            var conexao = ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ConnectionString;
            var consulta = "Select count(*) from viewusuarioperfil where idperfil = @idperfil and login = @login and senha = @senha";
            bool resultado = false;
            senha = Criptografia.GerarHashMd5(senha);

            MySqlConnection con = new MySqlConnection(conexao);
            MySqlCommand cmd = new MySqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);
            cmd.Parameters.AddWithValue("@idperfil", "a2751561-59ee-4d91-9d6c-8adbb1ba36bd");

            try {
                con.Open();
                resultado = (Convert.ToInt32(cmd.ExecuteScalar()) > 0);
            } catch (Exception) {
                
            } finally {
                if (con.State == System.Data.ConnectionState.Open) {
                    con.Close();
                }
            }
            return resultado;
        }
    }
}