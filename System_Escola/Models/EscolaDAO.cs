using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Escola.Database;
using System_Escola.Models;
using MySql.Data.MySqlClient;
using System_Escola.Helpers;

namespace System_Escola.Models
{
    internal class EscolaDAO
    {
        private Conexao _conn = new Conexao();

        public void Insert(Escola escola)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into Escola Values (null, @nome, @razao, @cnpj, @insc, @tipo, @data_cri, @resp, @resp_tel," +
                    "@email, @telefone_esc, @rua, @numero, @bairro, @complemento, @cep, @cidade, @estado);";

                comando.Parameters.AddWithValue("@nome", escola.Nome);
                comando.Parameters.AddWithValue("@razao", escola.Razao);
                comando.Parameters.AddWithValue("@cnpj", escola.Cnpj);
                comando.Parameters.AddWithValue("@insc", escola.Inscricao);
                comando.Parameters.AddWithValue("@tipo", escola.Tipo);
                comando.Parameters.AddWithValue("@data_cri", escola.Data?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@resp", escola.Responsavel);
                comando.Parameters.AddWithValue("@resp_tel", escola.TelefoneResponsavel);
                comando.Parameters.AddWithValue("@email", escola.Email);
                comando.Parameters.AddWithValue("@telefone_esc", escola.Telefone);
                comando.Parameters.AddWithValue("@rua", escola.Rua);
                comando.Parameters.AddWithValue("@numero", escola.Numero);
                comando.Parameters.AddWithValue("@bairro", escola.Bairro);
                comando.Parameters.AddWithValue("@complemento", escola.Complemento);
                comando.Parameters.AddWithValue("@cep", escola.Cep);
                comando.Parameters.AddWithValue("@cidade", escola.Cidade);
                comando.Parameters.AddWithValue("@estado", escola.Estado);

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

        public List<Escola> List()
        {
            try
            {
                var lista = new List<Escola>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Escola";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var escola = new Escola();

                    escola.Id = reader.GetInt32("id_esc");
                    escola.Nome = DAOHelper.GetString(reader, "nome_fantasia_esc");
                    escola.Razao = DAOHelper.GetString(reader, "razao_social_esc");
                    escola.Cnpj = DAOHelper.GetString(reader, "cnpj_esc");
                    escola.Inscricao = DAOHelper.GetString(reader, "insc_estadual_esc");
                    escola._tipo = DAOHelper.GetString(reader, "tipo_esc");
                    escola.Data = DAOHelper.GetDateTime(reader, "data_criacao_esc");
                    escola.Responsavel = DAOHelper.GetString(reader, "responsavel_esc");
                    escola.TelefoneResponsavel = DAOHelper.GetString(reader, "responsavel_telefone_esc");
                    escola.Email = DAOHelper.GetString(reader, "email_esc");
                    escola.Telefone = DAOHelper.GetString(reader, "telefone_esc");
                    escola.Rua = DAOHelper.GetString(reader, "rua_esc");
                    escola.Numero = DAOHelper.GetString(reader, "numero_esc");
                    escola.Bairro = DAOHelper.GetString(reader, "bairro_esc");
                    escola.Complemento = DAOHelper.GetString(reader, "complemento_esc");
                    escola.Cep = DAOHelper.GetString(reader, "cep_esc");
                    escola.Cidade = DAOHelper.GetString(reader, "cidade_esc");
                    escola.Estado = DAOHelper.GetString(reader, "estado_esc");

                    lista.Add(escola);
                }

                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void Delete(Escola t)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "delete from Escola where id_esc = @id";

                comando.Parameters.AddWithValue("@id", t.Id);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                    throw new Exception("Registro não removido da base de dados." +
                        "Verifique e tente novamente");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Update(Escola escola)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Escola SET " +
                    "nome_fantasia_esc = @nomeFantasia, razao_social_esc = @razaoSocial, cnpj_esc = @cnpj, insc_estadual_esc = @inscEstadual, tipo_esc = @tipo, " +
                    "data_criacao_esc = @data_criacao, responsavel_esc = @resp, responsavel_telefone_esc = @resp_tel, email_esc = @email, " +
                    "telefone_esc = @telefone, rua_esc = @rua, numero_esc = @numero, bairro_esc = @bairro, complemento_esc = @complemento, cep_esc = " +
                    "@cep, cidade_esc = @cidade, estado_esc = @estado" +
                    " Where id_esc = @id";


                comando.Parameters.AddWithValue("@id", escola.Id);
                comando.Parameters.AddWithValue("@nomeFantasia", escola.Nome);
                comando.Parameters.AddWithValue("@razaoSocial", escola.Razao);
                comando.Parameters.AddWithValue("@cnpj", escola.Cnpj);
                comando.Parameters.AddWithValue("@inscEstadual", escola.Inscricao);
                comando.Parameters.AddWithValue("@tipo", escola.Tipo);
                comando.Parameters.AddWithValue("@data_criacao", escola.Data?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@resp", escola.Responsavel);
                comando.Parameters.AddWithValue("@resp_tel", escola.TelefoneResponsavel);
                comando.Parameters.AddWithValue("@email", escola.Email);
                comando.Parameters.AddWithValue("@telefone", escola.Telefone);
                comando.Parameters.AddWithValue("@rua", escola.Rua);
                comando.Parameters.AddWithValue("@numero", escola.Numero);
                comando.Parameters.AddWithValue("@bairro", escola.Bairro);
                comando.Parameters.AddWithValue("@complemento", escola.Complemento);
                comando.Parameters.AddWithValue("@cep", escola.Cep);
                comando.Parameters.AddWithValue("@cidade", escola.Cidade);
                comando.Parameters.AddWithValue("@estado", escola.Estado);


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
