using MySql.Data.MySqlClient;

namespace LT.NET_project_cuoiki.DAO
{
    public class CheckoutDAO
    {
        public void addCheckout(string fullname, string hnum, string ward, string county, string province,string mail,string phone, string note)
        {
            string query_order = "";
            string query_order_detail = "";
            string query_address = "INSERT INTO address(hnum_sname,ward_commune,county_district,province_city) VALUES (@hnum,@ward,@county,@province)";

            MySqlConnection mySqlConnection = new ConnectionMysql().OpenConnection();            

            MySqlCommand commandAddress= new MySqlCommand();
            commandAddress.Connection = mySqlConnection;
            commandAddress.CommandText = query_address;

            commandAddress.Parameters.AddWithValue("@hnum", hnum);
            commandAddress.Parameters.AddWithValue("@ward", ward);
            commandAddress.Parameters.AddWithValue("@county", county);
            commandAddress.Parameters.AddWithValue("@province", province);

            commandAddress.ExecuteNonQuery();


        }
    }
}