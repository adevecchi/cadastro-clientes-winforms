using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public abstract class AcessoHelper
    {
        private string stringConexao = ConfigurationManager.ConnectionStrings["BancoDeDados"].ToString().Trim();

        protected int Executar(string query, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexao = new SqlConnection(stringConexao);
            comando.Connection = conexao;
            comando.CommandType = CommandType.Text;
            comando.CommandText = query;

            foreach (var item in parametros)
                comando.Parameters.Add(item);

            int affectdRow = 0;
            try
            {
                conexao.Open();

                affectdRow = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Close();
            }

            return affectdRow;
        }

        protected DML.Cliente Consultar(string query, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexao = new SqlConnection(stringConexao);

            comando.Connection = conexao;
            comando.CommandType = CommandType.Text;
            comando.CommandText = query;

            foreach (var item in parametros)
                comando.Parameters.Add(item);

            DML.Cliente cliente = null;

            try
            {
                conexao.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    cliente = new DML.Cliente();
                    cliente.Id = int.Parse(reader["Id"].ToString());
                    cliente.Nome = reader["Nome"].ToString();
                    cliente.Endereco = reader["Endereco"].ToString();
                    cliente.Bairro = reader["Bairro"].ToString();
                    cliente.Cidade = reader["Cidade"].ToString();
                    cliente.Uf = reader["Uf"].ToString();
                    cliente.Cep = reader["Cep"].ToString();
                    cliente.Telefone = reader["Telefone"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Close();
            }

            return cliente;
        }
    }
}
