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
   public class LocacaoController
    {

        public List<Locacao> Listar()
        {
            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=";

            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string query = "SELECT l.IdLocacao, l.IdClienteFkLocacao, l.IdFilmeFkLocacao, l.IdFuncionarioFkLocacao,l.DataLocacao, l.DataEntrega, l.ValorLocacao , c.Nome, m.NomeFilme , f.NomeFuncionario FROM locacao l JOIN cliente c ON l.IdClienteFkLocacao = c.IdCliente JOIN filme m ON l.IdFilmeFkLocacao = m.IdFilme JOIN funcionario f ON l.IdFuncionarioFkLocacao = f.IdFuncionario";

                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "Locacao");

                        List<Locacao> lstRetorno = ds.Tables["locacao"].AsEnumerable().Select(x => new Locacao
                        {
                            IdLocacao = x.Field<int>("IdLocacao"),
                            IdClienteFkLocacao = x.Field<int>("IdClienteFkLocacao"),
                            IdFilmeFkLocacao = x.Field<int>("IdFilmeFkLocacao"),
                            IdFuncionarioFkLocacao = x.Field<int>("IdFuncionarioFkLocacao"),
                            DataLocacao = x.Field<DateTime>("DataLocacao"),
                            DataEntrega = x.Field<DateTime>("DataEntrega"),
                            ValorLocacao = x.Field<string>("ValorLocacao"),
                            Nome = x.Field<string>("Nome"),
                            NomeFilme = x.Field<string>("NomeFilme"),
                            NomeFuncionario = x.Field<string>("NomeFuncionario"),

                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }

        public Locacao Buscar(int id)
        {
            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=";

            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {

                    string query = $"SELECT l.IdLocacao, l.IdClienteFkLocacao, l.IdFilmeFkLocacao, l.IdFuncionarioFkLocacao,l.DataLocacao, l.DataEntrega, l.ValorLocacao , c.Nome, m.NomeFilme , f.NomeFuncionario FROM locacao l JOIN cliente c ON l.IdClienteFkLocacao = c.IdCliente JOIN filme m ON l.IdFilmeFkLocacao = m.IdFilme JOIN funcionario f ON l.IdFuncionarioFkLocacao = f.IdFuncionario WHERE l.IdLocacao = {id}";

                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Locacao retorno = new Locacao();

                    while (reader.Read())
                    {

                        retorno.IdLocacao = (int)reader["IdLocacao"];
                        retorno.IdClienteFkLocacao = (int)reader["IdClienteFkLocacao"];
                        retorno.IdFilmeFkLocacao = (int)reader["IdFilmeFkLocacao"];
                        retorno.IdFuncionarioFkLocacao = (int)reader["IdFuncionarioFkLocacao"];
                        retorno.DataLocacao = (DateTime)reader["DataLocacao"];
                        retorno.DataEntrega = (DateTime)reader["DataEntrega"];
                        retorno.ValorLocacao = (string)reader["ValorLocacao"];
                        retorno.Nome = (string)reader["Nome"];
                        retorno.NomeFilme = (string)reader["NomeFilme"];
                        retorno.NomeFuncionario = (string)reader["NomeFuncionario"];
                      

                    }

                    return retorno;
                }
            }
        }

        public void Inserir(Locacao registro)
        {
            string strConexao = "SERVER=localhost; DataBase=locadora;Allow User Variables=True; UID=root; pwd=";

            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string query = $"INSERT INTO `locacao` ( `IdClienteFkLocacao`, `IdFilmeFkLocacao`, `IdFuncionarioFkLocacao`, `DataLocacao`, `DataEntrega`, `ValorLocacao`) VALUES('{registro.IdClienteFkLocacao}','{registro.IdFilmeFkLocacao}','{registro.IdFuncionarioFkLocacao}','{registro.DataLocacao:yyyy-MM-dd}','{registro.DataEntrega:yyyy-MM-dd}','{registro.ValorLocacao}')";
                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void Atualizar(Locacao registro)
        {
            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=";

            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string query = $"UPDATE `locacao` SET `IdClienteFkLocacao`= '{registro.IdClienteFkLocacao}',`IdFilmeFkLocacao`= '{registro.IdFilmeFkLocacao}',`IdFuncionarioFkLocacao`= '{registro.IdFuncionarioFkLocacao}',`DataLocacao`= '{registro.DataLocacao:yyyy-MM-dd}' ,`DataEntrega`= '{registro.DataEntrega:yyyy-MM-dd}' ,`ValorLocacao`= '{registro.ValorLocacao}' WHERE `IdLocacao` = { registro.IdLocacao}";


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
                    string query = $"DELETE FROM locacao WHERE IdLocacao = {id}";

                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
