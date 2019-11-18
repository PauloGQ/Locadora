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
    public class FuncionarioController
    {

        public List<Funcionario> Listar()
        {
            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=";

            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string query = "SELECT IdFuncionario, NomeFuncionario, EmailFuncionario, Senha FROM Funcionario";

                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "Funcionario");

                        List<Funcionario> lstRetorno = ds.Tables["funcionario"].AsEnumerable().Select(x => new Funcionario
                        {
                            IdFuncionario = x.Field<int>("IdFuncionario"),
                            NomeFuncionario = x.Field<string>("NomeFuncionario"),
                            EmailFuncionario = x.Field<string>("EmailFuncionario"),
                            Senha = x.Field<string>("Senha")
                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }

        public Funcionario Buscar(int id)
        {
            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=";

            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {

                    string query = $"SELECT IdFuncionario, NomeFuncionario, EmailFuncionario, Senha FROM Funcionario WHERE IdFuncionario = {id}";

                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Funcionario retorno = new Funcionario();

                    while (reader.Read())
                    {

                        retorno.IdFuncionario = (int)reader["IdFuncionario"];
                        retorno.NomeFuncionario = (string)reader["NomeFuncionario"];
                        retorno.EmailFuncionario = (string)reader["EmailFuncionario"];
                        retorno.Senha = (string)reader["Senha"];
                        
                    }

                    return retorno;
                }
            }
        }

        public void InserirFuncionario(Funcionario registro)
        {
            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=";

            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string query = $"INSERT INTO `funcionario`(`IdFuncionario`, `NomeFuncionario`, `EmailFuncionario`, `Senha`) VALUES ('','{registro.NomeFuncionario}','{registro.EmailFuncionario}','{registro.Senha}');";


                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void Atualizar(Funcionario registro)
        {
            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=";

            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string query = $"UPDATE `funcionario` SET `NomeFuncionario`='{registro.NomeFuncionario}',`EmailFuncionario`='{registro.EmailFuncionario}',`Senha`='{registro.Senha}' WHERE `IdFuncionario` = {registro.IdFuncionario}";

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
                    string query = $"DELETE FROM funcionario WHERE IdFuncionario = {id}";

                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

