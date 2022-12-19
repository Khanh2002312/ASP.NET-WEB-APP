using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LT.NET_project_cuoiki
{
    public class ConnectionMysql
    {

        string ConnectionString = ConfigurationManager.ConnectionStrings["dbstr"].ConnectionString;
        MySqlConnection sqlCn;


        public DataTable SQL_query_to_DataTable(string strSQL)
        {
            sqlCn = OpenConnection();
            MySqlDataAdapter Adapter = new MySqlDataAdapter(strSQL, sqlCn);
            DataTable ds = new DataTable();
            try
            {
                Adapter.Fill(ds);
                CloseConnection(sqlCn);
            }
            catch (SqlException E)
            {
                string strDescriptionError = E.Message;
            }
            finally
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();
            }
            return ds;
        }

        public MySqlConnection OpenConnection()
        {
            MySqlConnection sqlCn = new MySqlConnection(ConnectionString);
            try
            {
                if (sqlCn.State == ConnectionState.Closed)
                    sqlCn.Open();
            }
            catch
            {
                return null;
            }
            return sqlCn;
        }

        public void CloseConnection(MySqlConnection sqlCn)
        {
            if (sqlCn != null)
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();
            }
        }


    }

}