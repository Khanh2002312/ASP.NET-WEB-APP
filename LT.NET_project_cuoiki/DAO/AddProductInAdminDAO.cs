using MySql.Data.MySqlClient;

namespace LT.NET_project_cuoiki.DAO
{
    public class AddProductInAdminDAO
    {

        public void AddProduct(int id, string title, string typeGem, int quantity,
            string category, string color, int price, string keyword, string designer, string ImageUpload, string mota)
        {
            string query_insert_color = "INSERT INTO product_gem_color() VALUES(@id_product, @id_color)";

            string query_insert_product = "INSERT INTO product(product.id, product.title, product.category_id, product.quantity, " +
                "product.price, product.discount, product.keyword, product.design, product.thumbnail, product.description)" +
                "VALUES (@id_product, @title, @category_id, @quantity, @price, @discount, @keyword, @design, @thumbnail, @description)";

            MySqlConnection mySqlConnection = new ConnectionMysql().OpenConnection();

            //
            MySqlCommand command_product = new MySqlCommand();
            command_product.Connection = mySqlConnection;
            command_product.CommandText = query_insert_product;

            command_product.Parameters.AddWithValue("@id_product", id);
            command_product.Parameters.AddWithValue("@title", title);
            command_product.Parameters.AddWithValue("@category_id", ProductAdminDAO.GetIdCategory(typeGem, category));
            command_product.Parameters.AddWithValue("@quantity", quantity);
            command_product.Parameters.AddWithValue("@price", price);
            command_product.Parameters.AddWithValue("@keyword", keyword);
            command_product.Parameters.AddWithValue("@design", designer);
            command_product.Parameters.AddWithValue("@thumbnail", ImageUpload);
            command_product.Parameters.AddWithValue("@description", mota);

            command_product.Parameters.AddWithValue("@discount", 0);
            command_product.Parameters.AddWithValue("@is_on_sale", 1);
            command_product.Parameters.AddWithValue("@created_at", "now()");
            command_product.Parameters.AddWithValue("@updated_at", "now()");
            command_product.Parameters.AddWithValue("@created_by", 1);
            command_product.Parameters.AddWithValue("@updated_by", 1);

            command_product.ExecuteNonQuery();

            //
            MySqlCommand command_color = new MySqlCommand();
            command_color.Connection = mySqlConnection;
            command_color.CommandText = query_insert_color;

            command_color.Parameters.AddWithValue("@id_product", id);
            command_color.Parameters.AddWithValue("@id_color", ProductAdminDAO.getColor(color));

            command_color.ExecuteNonQuery();
        }



    }
}