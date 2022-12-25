using LT.NET_project_cuoiki.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace LT.NET_project_cuoiki.DAO
{
    public class CheckoutDAO
    {
        public int getTotal(Dictionary<string, CartItem> map)
        {
            int result = 0;
            foreach (KeyValuePair<string, CartItem> entry in map)
            {
                if (entry.Value.Product.Discount == 0)
                {
                    result += entry.Value.Product.Price * entry.Value.Quantity;

                }
                else
                {
                    result += entry.Value.Product.Discount * entry.Value.Quantity;
                }
            }
            return result;
        }
        public int getAddressId(string hnum, string ward, string county, string province)
        {
            int result = 0;
            ConnectionMysql connectionMysql = new ConnectionMysql();
            var d = connectionMysql.SQL_query_to_DataTable("SELECT * FROM address WHERE hnum_sname = '" + hnum + "' AND ward_commune ='" + ward + "'AND county_district = '" + county + "' AND province_city = '" + province + "'");
            foreach (DataRow r in d.Rows)
            {
                result = Int32.Parse(r["id"].ToString());

            }
            return result;
        }
        public int getOrderId(string fullname, int addId, string mail, string phone, int total)
        {
            int result = 0;
            ConnectionMysql connectionMysql = new ConnectionMysql();
            var d = connectionMysql.SQL_query_to_DataTable("SELECT * FROM `order` WHERE full_name = '" + fullname + "' AND shipping_address = " + addId + " AND email = '" + mail + "' AND  phone_number = '" + phone + "' AND order_total = " + total + "");
            foreach (DataRow r in d.Rows)
            {
                result = Int32.Parse(r["id"].ToString());
            }
            return result;
        }
        public void addCheckout(string fullname, string hnum, string ward, string county, string province, string mail, string phone, string note, Dictionary<string, CartItem> map, string userId)
        {

            string query_order = "INSERT INTO `order`(full_name,user_id,shipping_address,email,phone_number,order_date,order_total,payment_method,`status`) \r\nVALUES (@name,@userId,@addId,@mail,@phone,NOW(),@ordertotal,'Ship COD',1)";
            string query_order_detail = "INSERT INTO order_details(product_id,order_id,price,quantity,total_money) VALUES (@productId,@orderId,@price,@quantity,@total)";
            string query_address = "INSERT INTO address(hnum_sname,ward_commune,county_district,province_city) VALUES (@hnum,@ward,@county,@province)";

            MySqlConnection mySqlConnection = new ConnectionMysql().OpenConnection();
            if (getAddressId(hnum, ward, county, province) == 0)
            {
                MySqlCommand commandAddress = new MySqlCommand();
                commandAddress.Connection = mySqlConnection;
                commandAddress.CommandText = query_address;

                commandAddress.Parameters.AddWithValue("@hnum", hnum);
                commandAddress.Parameters.AddWithValue("@ward", ward);
                commandAddress.Parameters.AddWithValue("@county", county);
                commandAddress.Parameters.AddWithValue("@province", province);

                commandAddress.ExecuteNonQuery();
            }


            MySqlCommand commandOrder = new MySqlCommand();
            commandOrder.Connection = mySqlConnection;
            commandOrder.CommandText = query_order;

            commandOrder.Parameters.AddWithValue("@name", fullname);
            if (userId != null)
            {
                commandOrder.Parameters.AddWithValue("@userId", Int32.Parse(userId));
            }
            else
            {
                commandOrder.Parameters.AddWithValue("@userId", userId);
            }
            commandOrder.Parameters.AddWithValue("@addId", getAddressId(hnum, ward, county, province));
            commandOrder.Parameters.AddWithValue("@mail", mail);
            commandOrder.Parameters.AddWithValue("@phone", phone);
            commandOrder.Parameters.AddWithValue("@ordertotal", getTotal(map));

            commandOrder.ExecuteNonQuery();

            foreach (KeyValuePair<string, CartItem> entry in map)
            {
                MySqlCommand commandOrderDetail = new MySqlCommand();
                commandOrderDetail.Connection = mySqlConnection;
                commandOrderDetail.CommandText = query_order_detail;
                int total = 0;
                int price = 0;
                if (entry.Value.Product.Discount == 0)
                {
                    price = entry.Value.Product.Price;
                    total = entry.Value.Product.Price * entry.Value.Quantity;
                }
                else
                {
                    price = entry.Value.Product.Discount;
                    total = entry.Value.Product.Discount * entry.Value.Quantity;
                }

                commandOrderDetail.Parameters.AddWithValue("@productId", entry.Key);
                commandOrderDetail.Parameters.AddWithValue("@orderId", getOrderId(fullname, getAddressId(hnum, ward, county, province), mail, phone, getTotal(map)));
                commandOrderDetail.Parameters.AddWithValue("@price", price);
                commandOrderDetail.Parameters.AddWithValue("@quantity", entry.Value.Quantity);
                commandOrderDetail.Parameters.AddWithValue("@total", total);

                commandOrderDetail.ExecuteNonQuery();
            }

        }
    }
}