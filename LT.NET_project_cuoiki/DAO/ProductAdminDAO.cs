using LT.NET_project_cuoiki.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace LT.NET_project_cuoiki.DAO
{
    public class ProductAdminDAO
    {

        public List<ProductEntity> loadListProductFromDB()
        {
            List<ProductEntity> listPro
                = new List<ProductEntity>();
            ConnectionMysql cms = new ConnectionMysql();
            var query = cms.SQL_query_to_DataTable("select * from product");
            foreach (DataRow dr in query.Rows)
            {
                ProductEntity pe = new ProductEntity(Int32.Parse(dr["id"].ToString()), Int32.Parse(dr["category_id"].ToString()), dr["title"].ToString(),
                    dr["thumbnail"].ToString(), Int32.Parse(dr["quantity"].ToString()), CheckStatusProduct(Int32.Parse(dr["quantity"].ToString())),
                    Int32.Parse(dr["price"].ToString()), GetNameCategoryWithId(Int32.Parse(dr["category_id"].ToString())));
                listPro.Add(pe);
            }
            return listPro;
        }

        public static string GetNameGem(int id)
        {
            string result = "";
            ConnectionMysql cms = new ConnectionMysql();
            var query = cms.SQL_query_to_DataTable("SELECT * FROM category");
            foreach (DataRow dr in query.Rows)
            {
                if (Int32.Parse(dr["id"].ToString()) == id)
                {
                    result = dr["name"].ToString();
                }
            }
            return result;
        }

        public static List<Color> ListColor()
        {
            List<Color> listC
                = new List<Color>();
            ConnectionMysql cms = new ConnectionMysql();
            var query = cms.SQL_query_to_DataTable("SELECT * FROM gem_color");
            foreach (DataRow dr in query.Rows)
            {
                Color c = new Color(Int32.Parse(dr["id"].ToString()), dr["color"].ToString());
                listC.Add(c);
            }
            return listC;
        }

        public static List<ColorProduct> ListColorProduct()
        {
            List<ColorProduct> listC
                = new List<ColorProduct>();
            ConnectionMysql cms = new ConnectionMysql();
            var query = cms.SQL_query_to_DataTable("SELECT * FROM product_gem_color");
            foreach (DataRow dr in query.Rows)
            {
                ColorProduct c = new ColorProduct(Int32.Parse(dr["product_id"].ToString()), 
                    Int32.Parse(dr["gem_color_id"].ToString()));
                listC.Add(c);
            }
            return listC;
        }

        public static string CheckStatusProduct(int quantity)
        {
            string result;
            if (quantity > 0)
            {
                result = "Còn hàng";
            }
            else
            {
                result = "Hết hàng";
            }
            return result;
        }

        public static string GetNameCategoryWithId(int category_id)
        {
            string result = "";
            ConnectionMysql cms = new ConnectionMysql();
            var query_cat = cms.SQL_query_to_DataTable("select * from category");
            foreach (DataRow dr in query_cat.Rows)
            {
                int id = Convert.ToInt32(dr["id"]);
                if (category_id == id)
                {
                    int parent_id = Convert.ToInt32(dr["parent_id"]);
                    foreach (DataRow dr1 in query_cat.Rows)
                    {
                        int id2 = Convert.ToInt32(dr1["id"]);
                        if (parent_id == id2)
                        {
                            result = dr1["name"].ToString();
                        }
                    }
                }
            }
            return result;
        }

        public static int GetIdParent(string category)
        {
            int id_parent = 0;
            ConnectionMysql cms = new ConnectionMysql();
            var query_cat = cms.SQL_query_to_DataTable("select * from category");
            foreach (DataRow dr in query_cat.Rows)
            {
                if (dr["name"].ToString().Equals(category))
                {
                    id_parent = Int32.Parse(dr["id"].ToString());
                }
            }
            return id_parent;
        }

        public static int GetIdCategory(string typeGem, string category)
        {
            int id_cat = 0;
            ConnectionMysql cms = new ConnectionMysql();
            var query_cat = cms.SQL_query_to_DataTable("select * from category");
            foreach (DataRow dr in query_cat.Rows)
            {
                if (typeGem.Equals(dr["name"]))
                {
                    if (Int32.Parse(dr["parent_id"].ToString()) == GetIdParent(category))
                    {
                        id_cat = Int32.Parse(dr["id"].ToString());
                    }
                }
            }
            return id_cat;
        }

        public static int getColor(string color)
        {
            int id_color = 0;
            ConnectionMysql cms = new ConnectionMysql();
            var query_cat = cms.SQL_query_to_DataTable("SELECT * FROM gem_color");
            foreach (DataRow dr in query_cat.Rows)
            {
                if (color.Equals(dr["color"].ToString()))
                {
                    id_color = Int32.Parse(dr["id"].ToString());
                }
            }
            return id_color;
        }

        public static List<CategoryModel> GetListCatByName(string name)
        {
            List<CategoryModel> list = new List<CategoryModel>();
            ConnectionMysql cms = new ConnectionMysql();
            var query_cat = cms.SQL_query_to_DataTable("select * from category");
            foreach (DataRow dr in query_cat.Rows)
            {
                if (dr["name"].ToString().Equals(name))
                {
                    list.Add(new CategoryModel(Int32.Parse(dr["id"].ToString()), Int32.Parse(dr["parent_id"].ToString()), dr["name"].ToString()));
                }
            }
            return list;
        }

        public static int GetIdCategoryWithName(string name, string catName)
        {
            int id = 0;
            ConnectionMysql cms = new ConnectionMysql();
            var query_cat = cms.SQL_query_to_DataTable("select * from category");

            List<CategoryModel> licat = GetListCatByName(name);
            foreach(CategoryModel cm in licat)
            {
                if(cm.Parent_id == GetIdParent(catName))
                {
                    id = cm.Id;
                }
            }
            return id;
        }

        //foreach (DataRow dr in query_cat.Rows)
        //{
        //    if (dr["name"].ToString().Equals(name))
        //    {
        //        if (Int32.Parse(dr["parent_id"].ToString()) == GetIdParent(catName))
        //        {
        //            id = Int32.Parse(dr["id"].ToString());
        //        }
        //    }
        //}



        // function
        public void AddProduct(int id, string title, string typeGem, int quantity,
           string category, string color, int price, string keyword, string designer, string ImageUpload, string mota)
        {
            string query_insert_color = "INSERT INTO product_gem_color() VALUES(@id_product, @id_color)";

            string query_insert_product = "INSERT INTO product(product.id, product.title, product.category_id, product.quantity, " +
                "product.price, product.keyword, product.design, product.thumbnail, product.description, " +
                "product.is_on_sale, product.created_at, product.updated_at, product.discount) VALUES " +
                "(@id_product, @title, @category_id, @quantity, @price, @keyword, @design, @thumbnail, " +
                "@description, @is_on_sale, @created_at, @updated_at, @discount)";


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


            command_product.Parameters.AddWithValue("@is_on_sale", 0);
            command_product.Parameters.AddWithValue("@created_at", DateTime.Now);
            command_product.Parameters.AddWithValue("@updated_at", DateTime.Now);
            command_product.Parameters.AddWithValue("@discount", 0);

            command_product.ExecuteNonQuery();

            //
            MySqlCommand command_color = new MySqlCommand();
            command_color.Connection = mySqlConnection;
            command_color.CommandText = query_insert_color;

            command_color.Parameters.AddWithValue("@id_product", id);
            command_color.Parameters.AddWithValue("@id_color", ProductAdminDAO.getColor(color));

            command_color.ExecuteNonQuery();
        }

        public void DeleteProduct(int pid)
        {
            string que_del_pro_color = "DELETE FROM product_gem_color WHERE product_gem_color.product_id = @pid_color";
            string que_del_pro = "DELETE FROM product WHERE product.id = @pid_pro";

            MySqlConnection msc = new ConnectionMysql().OpenConnection();

            //
            MySqlCommand Command_del_color = new MySqlCommand();
            Command_del_color.Connection = msc;
            Command_del_color.CommandText = que_del_pro_color;

            Command_del_color.Parameters.AddWithValue("@pid_color", pid);

            Command_del_color.ExecuteNonQuery();

            //
            MySqlCommand Command_del_product = new MySqlCommand();
            Command_del_product.Connection = msc;
            Command_del_product.CommandText = que_del_pro;

            Command_del_product.Parameters.AddWithValue("@pid_pro", pid);

            Command_del_product.ExecuteNonQuery();

        }

        public void EditProduct(int e_id, string e_name, string e_catName,
            string e_nameGem, string e_quantity, string e_color, int e_price)
        {
            string query_alter_color = "UPDATE product_gem_color SET gem_color_id = @gem_color_id WHERE product_id = @id";
            string query_alter_product = "UPDATE product SET title = @title, category_id = @category_id, quantity = @quantity, price = @price WHERE id = @id";

           

            MySqlConnection msc = new ConnectionMysql().OpenConnection();

            //
            MySqlCommand Command_alter_color = new MySqlCommand();
            Command_alter_color.Connection = msc;
            Command_alter_color.CommandText = query_alter_color;

            Command_alter_color.Parameters.AddWithValue("@id", e_id);
            Command_alter_color.Parameters.AddWithValue("@gem_color_id", getColor(e_color));

            Command_alter_color.ExecuteNonQuery();

            //
            MySqlCommand Command_alter_product = new MySqlCommand();
            Command_alter_product.Connection = msc;
            Command_alter_product.CommandText = query_alter_product;

            Command_alter_product.Parameters.AddWithValue("@id", e_id);
            Command_alter_product.Parameters.AddWithValue("@title", e_name);
            Command_alter_product.Parameters.AddWithValue("@category_id", GetIdCategoryWithName(e_nameGem, e_catName));
            Command_alter_product.Parameters.AddWithValue("@quantity", e_quantity);
            Command_alter_product.Parameters.AddWithValue("@price", e_price);

            Command_alter_product.ExecuteNonQuery();

        }

    }
}