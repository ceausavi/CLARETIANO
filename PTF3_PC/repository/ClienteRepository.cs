using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace banco_repository1
{
    public class ClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ToString();
        }

        public bool Inserir(Cliente cliente)
        {
            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                try
                {
                    conexao.Open();

                    string sql = "INSERT INTO Clientes (IdClientes, Nome, Endereco, Telefone) " +
                        "VALUES (@vId, @vNome, @vEndereco, @vTelefone)";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@vId", cliente.IdClientes);
                    comando.Parameters.AddWithValue("@vNome", cliente.Nome);
                    comando.Parameters.AddWithValue("@vEndereco", cliente.Endereco);
                    comando.Parameters.AddWithValue("@vTelefone", cliente.Telefone);

                    return comando.ExecuteNonQuery() > 0;
                }
                catch
                {
                    throw;
                }
            }
        }

        public Cliente Buscar(int idClientes)
        {
            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                try
                {
                    conexao.Open();

                    string sql = "SELECT * FROM Clientes WHERE IdClientes = @vId";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@vId", idClientes);

                    MySqlDataReader leitor = comando.ExecuteReader();

                    if (leitor.Read())
                    {
                        return new Cliente
                        {
                            IdClientes = Convert.ToInt32(leitor["IdClientes"]),
                            Nome = leitor["Nome"].ToString(),
                            Endereco = leitor["Endereco"].ToString(),
                            Telefone = leitor["Telefone"].ToString()
                        };
                    }
                    return null;
                }
                catch
                {
                    throw;
                }
            }
        }

        public bool Atualizar(Cliente cliente)
        {
            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                try
                {
                    conexao.Open();

                    string sql = "UPDATE Clientes SET Nome = @vNome, Endereco = @vEndereco, Telefone = @vTelefone " +
                        "WHERE IdClientes = @vId";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@vId", cliente.IdClientes);
                    comando.Parameters.AddWithValue("@vNome", cliente.Nome);
                    comando.Parameters.AddWithValue("@vEndereco", cliente.Endereco);
                    comando.Parameters.AddWithValue("@vTelefone", cliente.Telefone);

                    return comando.ExecuteNonQuery() > 0;
                }
                catch
                {
                    throw;
                }
            }
        }

        public bool Deletar(int idClientes)
        {
            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                try
                {
                    conexao.Open();

                    string sql = "DELETE FROM Clientes WHERE IdClientes = @vId";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@vId", idClientes);

                    return comando.ExecuteNonQuery() > 0;
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
