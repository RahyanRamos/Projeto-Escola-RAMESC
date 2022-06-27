using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ProjetoEscola.Database;
using ProjetoEscola.Helpers;

namespace ProjetoEscola.Models
{
    internal class CursoDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Curso curso)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO curso VALUES(null, @nome, @descricao, @carga, @turno);";

                comando.Parameters.AddWithValue("@nome", curso.Nome);
                comando.Parameters.AddWithValue("@descricao", curso.Descricao);
                comando.Parameters.AddWithValue("@carga", curso.CargaHoraria);
                comando.Parameters.AddWithValue("@turno", curso.Turno);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Curso> List()
        {
            try
            {
                var lista = new List<Curso>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT id_cur, nome_cur, carga_horaria_cur, turno_cur FROM curso;";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var curso = new Curso();

                    curso.Id = reader.GetInt32("id_cur");
                    curso.Nome = DAOHelper.GetString(reader, "nome_cur");
                    curso.CargaHoraria = DAOHelper.GetString(reader, "carga_horaria_cur");
                    curso.Turno = DAOHelper.GetString(reader, "turno_cur");

                    lista.Add(curso);
                }
                reader.Close();

                return lista;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Curso curso)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM curso WHERE id_cur = @id";

                comando.Parameters.AddWithValue("@id", curso.Id);

                var resultado = comando.ExecuteNonQuery();

                if(resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao realizar a ação!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Curso curso)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE curso SET nome_cur = @nome, carga_horaria_cur = @carga, turno_cur = @turno, descricao_cur = @descricao WHERE id_cur = @id";

                comando.Parameters.AddWithValue("@id", curso.Id);
                comando.Parameters.AddWithValue("@nome", curso.Nome);
                comando.Parameters.AddWithValue("@carga", curso.CargaHoraria);
                comando.Parameters.AddWithValue("@turno", curso.Turno);
                comando.Parameters.AddWithValue("@descricao", curso.Descricao);

                var resultado = comando.ExecuteNonQuery();

                if(resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao atualizar os registros!");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
