using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Escola.Helpers;
using System_Escola.Database;
using MySql.Data.MySqlClient;

namespace System_Escola.Models
{
    internal class CursoDAO
    {
        private Conexao _conn = new Conexao();

        public void Insert(Curso curso)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into Curso Values (null, @nome, @cargaHoraria, @descricao, @turno);";

                comando.Parameters.AddWithValue("@nome", curso.Nome);
                comando.Parameters.AddWithValue("@cargaHoraria", curso.CargaHoraria);
                comando.Parameters.AddWithValue("@descricao", curso.Descricao);
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

                comando.CommandText = "SELECT * FROM Curso";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var curso = new Curso();

                    curso.Id = reader.GetInt32("id_cur");
                    curso.Nome = DAOHelper.GetString(reader, "nome_cur");
                    curso.CargaHoraria = DAOHelper.GetString(reader, "carga_horaria_cur");
                    curso.Descricao = DAOHelper.GetString(reader, "descricao_cur");
                    curso.Turno = DAOHelper.GetString(reader, "turno_cur"); 


                    lista.Add(curso);
                }

                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Curso t)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "DELETE FROM Curso WHERE id_cur = @id";

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Registro não removido da base de dados. Verifique e tente novamente.");
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _conn.Close();
            }
        }

        public void Update(Curso curso)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Curso SET " +
                    "Nome_cur = @nome, carga_horaria_cur = @cargaHoraria, descricao_cur = @descricao, turno_cur = @turno" +
                    " Where id_cur = @id";

                comando.Parameters.AddWithValue("@id", curso.Id);
                comando.Parameters.AddWithValue("@nome", curso.Nome);
                comando.Parameters.AddWithValue("@cargaHoraria", curso.CargaHoraria);
                comando.Parameters.AddWithValue("@descricao", curso.Descricao);
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

    }
}
