using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetCRUD
{
    public class Pessoa
    {
        public int id;
        public string nome;
        public string cidade;

        public bool gravar()
        {
            Banco bd = new Banco();

            SqlConnection cn = bd.abrirConexao();
            SqlTransaction transacao = cn.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Transaction = transacao;

            try
            {
                cmd.CommandText = "insert into Pessoas (nome, cidade)" +
                    " values (@nome, @cidade);";
                cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                cmd.Parameters.Add("@cidade", SqlDbType.VarChar);
                cmd.Parameters[0].Value = nome;
                cmd.Parameters[1].Value = cidade;

                cmd.ExecuteNonQuery();
                transacao.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transacao.Rollback();
                return false;
            }
            finally
            {
                bd.fecharConexao();
            }
        }

        public bool excluir()
        {
            Banco bd = new Banco();
            SqlConnection cn = bd.abrirConexao();
            SqlTransaction tran = cn.BeginTransaction();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cn;
            cmd.Transaction = tran;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from pessoas where" +
                " id = @id";

            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters[0].Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                bd.fecharConexao();
            }
        }

        public bool atualizar()
        {
            Banco bd = new Banco();
            SqlConnection cn = bd.abrirConexao();
            SqlTransaction tran = cn.BeginTransaction();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Transaction = tran;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update pessoas set nome = @nome, cidade = @cidade " +
                " where id = @id";

            cmd.Parameters.Add("@nome", SqlDbType.VarChar);
            cmd.Parameters.Add("@cidade", SqlDbType.VarChar);
            cmd.Parameters.Add("@id", SqlDbType.Int);

            cmd.Parameters[0].Value = nome;
            cmd.Parameters[1].Value = cidade;
            cmd.Parameters[2].Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                bd.fecharConexao();
            }
        }

        public Pessoa consultar(int id)
        {
            Banco bd = new Banco();

            try
            {
                SqlConnection cn = bd.abrirConexao();
                SqlCommand cmd = new SqlCommand("select * from pessoas", cn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetInt32(0) == id)
                    {
                        this.id = reader.GetInt32(0);
                        nome = reader.GetString(1);
                        cidade = reader.GetString(2);

                        return this;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                bd.fecharConexao();
            }
        }
    }
}