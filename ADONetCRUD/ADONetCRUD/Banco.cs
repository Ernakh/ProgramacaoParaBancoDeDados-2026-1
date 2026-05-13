using System;
using System.Data;
using System.Data.SqlClient;

namespace ADONetCRUD
{
    public class Banco
    {
        private string stringConexao =
            "Data Source=localhost; Initial Catalog=aulaADONet;" +
            "User ID=usuario; password=senha; language=Portuguese";

        private SqlConnection cn;

        public void conexao()
        {
            cn = new SqlConnection(stringConexao);
        }

        public SqlConnection abrirConexao()
        {
            try
            {
                conexao();
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void fecharConexao()
        {
            try
            {
                cn.Close();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public DataTable executarConsultaGenerica(string sql)
        {
            try
            {
                abrirConexao();

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                return null;
            }

            finally
            {
                fecharConexao();
            }
        }
    }
}
