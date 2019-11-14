using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Service
{
    public class ClienteController
    {

        public List<Cliente> Listar()
        {
            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=";

            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string query = "SELECT IdCliente, Nome, DataNascimento, Email,Cpf FROM Cliente";

                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "Cliente");

                        List<Cliente> lstRetorno = ds.Tables["cliente"].AsEnumerable().Select(x => new Cliente
                        {
                            IdCliente = x.Field<int>("IdCliente"),
                            Nome = x.Field<string>("Nome"),
                            DataNascimento = x.Field<DateTime>("DataNascimento"),
                            Email = x.Field<string>("Email"),
                            Cpf = x.Field<string>("Cpf")
                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }

        public Cliente Buscar(int id)
        {
            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=";

            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {

                    string query = $"SELECT * FROM cliente c JOIN telefone t ON c.IdCliente = t.IdClienteFkTelefone JOIN endereco e ON c.IdCliente = e.IdClienteFkEndereco WHERE c.IdCliente = {id}"; 

                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Cliente retorno = new Cliente();

                    while (reader.Read())
                    {

                        retorno.IdCliente = (int)reader["IdCliente"];
                        retorno.Nome = (string)reader["Nome"];
                        retorno.DataNascimento = (DateTime)reader["DataNascimento"];
                        retorno.Email = (string)reader["Email"];
                        retorno.Cpf = (string)reader["Cpf"];
                        retorno.IdTelefone = (int)reader["IdTelefone"];
                        retorno.TipoTelefone = (string)reader["TipoTelefone"];
                        retorno.Ddd = (string)reader["Ddd"];
                        retorno.NumeroTel = (string)reader["NumeroTel"];
                        retorno.IdClienteFkTelefone = (int)reader["IdClienteFkTelefone"];
                        retorno.IdEndereco = (int)reader["IdEndereco"];
                        retorno.Cep = (string)reader["Cep"]; 
                        retorno.Cidade = (string)reader["Cidade"];
                        retorno.Estado = (string)reader["Estado"];
                        retorno.Bairro = (string)reader["Bairro"];
                        retorno.Logradouro = (string)reader["Logradouro"];
                        retorno.Numero = (string)reader["Numero"];
                        retorno.Complemento = (string)reader["Complemento"];
                        retorno.IdClienteFkEndereco = (int)reader["IdClienteFkEndereco"];

                    }

                    return retorno;
                }
            }
        }

        public void Inserir(Cliente registro)
        {
            string strConexao = "SERVER=localhost; DataBase=locadora;Allow User Variables=True; UID=root; pwd=";

            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string query = $"INSERT INTO cliente (IdCliente, Nome, DataNascimento, Email, Cpf ) VALUES ('{registro.IdCliente}', '{registro.Nome}', '{registro.DataNascimento:yyyy-MM-dd}', '{registro.Email}', '{registro.Cpf}'); SET @var = LAST_INSERT_ID(); INSERT INTO telefone(IdTelefone, TipoTelefone, Ddd, NumeroTel, IdClienteFkTelefone) VALUES('{registro.IdTelefone}', '{registro.TipoTelefone}', '{registro.Ddd}', '{registro.NumeroTel}', @var); INSERT INTO endereco(IdEndereco, Cep, Cidade, Estado, Bairro, Logradouro, Numero, Complemento, IdClienteFkEndereco) VALUES('{registro.IdEndereco}', '{registro.Cep}', '{registro.Cidade}', '{registro.Estado}', '{registro.Bairro}', '{registro.Logradouro}', '{registro.Numero}', '{registro.Complemento}', @var);";

                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                        
                }

            }
        }

        public void Atualizar(Cliente registro)
        {
            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=";

            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string query = $@"UPDATE cliente c SET 
                                    c.Nome = '{registro.Nome}',
                                    c.DataNascimento = '{registro.DataNascimento:yyyy-MM-dd}',
                                    c.Email = '{registro.Email}',
                                    c.Cpf = '{registro.Cpf}'
                                    WHERE c.IdCliente = {registro.IdCliente};                                    


                                    UPDATE telefone t SET
                                    t.TipoTelefone = '{registro.TipoTelefone}',
                                    t.Ddd = '{registro.Ddd}',
                                    t.NumeroTel = '{registro.NumeroTel}'
                                    WHERE t.IdClienteFkTelefone = {registro.IdCliente};
                                    
                                    UPDATE endereco e SET
                                    e.Cep = '{registro.Cep}',
                                    e.Cidade = '{registro.Cidade}',
                                    e.Estado = '{registro.Estado}',
                                    e.Bairro = '{registro.Bairro}',
                                    e.Logradouro = '{registro.Logradouro}',
                                    e.numero = '{registro.Numero}',
                                    e.Complemento = '{registro.Complemento}'
                                    WHERE e.IdClienteFkEndereco = {registro.IdCliente};";

                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Excluir(int id)
        {
            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=";

            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string query = $"DELETE FROM cliente WHERE IdCliente = {id}";

                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}

