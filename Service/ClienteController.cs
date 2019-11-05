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

                    string query = $"SELECT IdCliente, Nome, DataNascimento, Email,Cpf FROM cliente WHERE IdCliente = {id}";
                    
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

                    }

                    return retorno;
                }
            }
        }

        public void Inserir(Cliente registro)
        {
            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=";

            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string query = $"INSERT INTO cliente (IdCliente, Nome, DataNascimento, Email, Cpf ) VALUES ('{registro.IdCliente}','{registro.Nome}', '{registro.DataNascimento:yyyy-MM-dd}', '{registro.Email}', '{registro.Cpf}')";

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
                    string query = $@"UPDATE cliente SET
                                    Nome = '{registro.Nome}',
                                    DataNascimento = '{registro.DataNascimento:yyyy-MM-dd}',
                                    Email = '{registro.Email}',
                                    Cpf = '{registro.Cpf}'
                                    WHERE IdCliente = {registro.IdCliente}";

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

