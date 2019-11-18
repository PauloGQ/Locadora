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
    public class FilmeController
    {

        public List<Filme> Listar()
        {
            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=";

            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string query = "SELECT * FROM filme";

                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "Filme");

                        List<Filme> lstRetorno = ds.Tables["filme"].AsEnumerable().Select(x => new Filme
                        {
                            IdFilme = x.Field<int>("IdFilme"),
                            NomeFilme = x.Field<string>("NomeFilme"),
                            Imagem = x.Field<Byte[]>("Imagem"),
                            Cartaz = x.Field<Byte[]>("Cartaz"),
                            IdGeneroFkFilme = x.Field<int>("IdGeneroFkFilme")

                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }

        public Filme Buscar(int id)
        {
            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=";

            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {

                    string query = $"SELECT * FROM filme f JOIN genero g ON f.IdGeneroFkFilme = g.IdGenero JOIN classificacao c ON f.IdClassificacaoFkFilme = c.IdClassificacao WHERE f.IdFilme = {id}";

                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Filme retorno = new Filme();

                    while (reader.Read())
                    {

                        retorno.IdFilme = (int)reader["IdFilme"];
                        retorno.NomeFilme = (string)reader["NomeFilme"];
                        retorno.Sinopse = (string)reader["Sinopse"];
                        retorno.TempoDuracao = (string)reader["TempoDuracao"];
                        retorno.Ano = (string)reader["Ano"];
                        retorno.Imagem = (byte[])reader["Imagem"];
                        retorno.Cartaz = (byte[])reader["Cartaz"];
                        retorno.IdClassificacaoFkFilme = (int)reader["IdClassificacaoFkFilme"];
                        retorno.IdGeneroFkFilme = (int)reader["IdGeneroFkFilme"];
                        retorno.IdGenero = (int)reader["IdGenero"];
                        retorno.GeneroFilme = (string)reader["GeneroFilme"];
                        retorno.IdClassificacao = (int)reader["IdClassificacao"];
                        retorno.Classifica = (string)reader["Classifica"];


                    }

                    return retorno;
                }
            }
        }

        public void Inserir(Filme registro)
        {
            string strConexao = "SERVER=localhost; DataBase=locadora;Allow User Variables=True; UID=root; pwd=";

            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    
                    string query = $"INSERT INTO filme(IdFilme, NomeFilme, Sinopse, TempoDuracao, Ano, IdClassificacaoFkFilme, IdGeneroFkFilme, Imagem, Cartaz) VALUES ('{registro.IdFilme}', '{registro.NomeFilme}', '{registro.Sinopse}', '{registro.TempoDuracao}', '{registro.Ano}' , '{registro.IdClassificacaoFkFilme}', '{registro.IdGeneroFkFilme}', '{registro.Imagem} '{registro.Cartaz}');";
                    
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
