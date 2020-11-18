using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class Cliente : AcessoHelper
    {
        public DML.Cliente Consultar(int id)
        {
            string query = "SELECT * FROM Cliente WHERE Id = @Id";

            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Id", id));

            return Consultar(query, parametros);
        }

        public int Salvar(DML.Cliente cliente)
        {
            string query = "INSERT INTO Cliente (Nome, Endereco, Bairro, Cidade, Uf, Cep, Telefone)"
                            + " VALUES (@Nome, @Endereco, @Bairro, @Cidade, @Uf, @Cep, @Telefone)";

            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Nome", cliente.Nome));
            parametros.Add(new SqlParameter("@Endereco", cliente.Endereco));
            parametros.Add(new SqlParameter("@Bairro", cliente.Bairro));
            parametros.Add(new SqlParameter("@Cidade", cliente.Cidade));
            parametros.Add(new SqlParameter("@Uf", cliente.Uf));
            parametros.Add(new SqlParameter("@Cep", cliente.Cep));
            parametros.Add(new SqlParameter("@Telefone", cliente.Telefone));

            return Executar(query, parametros);
        }

        public int Atualizzar(DML.Cliente cliente)
        {
            string query = "UPDATE Cliente SET Nome = @Nome, Endereco = @Endereco, Bairro = @Bairro, Cidade = @Cidade, Uf = @Uf, Cep = @Cep, Telefone = @Telefone"
                            + " WHERE Id = @Id";

            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Nome", cliente.Nome));
            parametros.Add(new SqlParameter("@Endereco", cliente.Endereco));
            parametros.Add(new SqlParameter("@Bairro", cliente.Bairro));
            parametros.Add(new SqlParameter("@Cidade", cliente.Cidade));
            parametros.Add(new SqlParameter("@Uf", cliente.Uf));
            parametros.Add(new SqlParameter("@Cep", cliente.Cep));
            parametros.Add(new SqlParameter("@Telefone", cliente.Telefone));
            parametros.Add(new SqlParameter("@Id", cliente.Id));

            return Executar(query, parametros);
        }

        public int Excluir(int id)
        {
            string query = "DELETE FROM Cliente WHERE Id = @Id";

            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Id", id));

            return Executar(query, parametros);
        }
    }
}
