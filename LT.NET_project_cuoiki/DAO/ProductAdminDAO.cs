using LT.NET_project_cuoiki.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

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
                ProductEntity pe = new ProductEntity(Int32.Parse(dr["id"].ToString()), dr["title"].ToString(),
                    dr["thumbnail"].ToString(), Int32.Parse(dr["quantity"].ToString()), CheckStatusProduct(Int32.Parse(dr["quantity"].ToString())),
                    Int32.Parse(dr["price"].ToString()), GetNameCategoryWithId(Int32.Parse(dr["category_id"].ToString())));
                listPro.Add(pe);
            }
            return listPro;
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

        public static List<CategoryModel> GetListIdOfCategory(string typeGem)
        {
            List<CategoryModel> list_id = new List<CategoryModel>();
            ConnectionMysql cms = new ConnectionMysql();
            var query_cat = cms.SQL_query_to_DataTable("select * from category");
            foreach (DataRow dr in query_cat.Rows)
            {
                if (typeGem.Equals(dr["name"].ToString()))
                {
                    CategoryModel cm = new CategoryModel();
                    cm.Id = Int32.Parse(dr["id"].ToString());
                    cm.Parent_id = Int32.Parse(dr["parent_id"].ToString());
                    cm.Name = dr["name"].ToString();
                    return list_id;
                }
            }
            return list_id;
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

       

        public static string GetTypeGem(int category_id)
        {
            string result = "";
            ConnectionMysql cms = new ConnectionMysql();
            var query_cat = cms.SQL_query_to_DataTable("select * from category");
            foreach (DataRow dr in query_cat.Rows)
            {
                int id = Convert.ToInt32(dr["id"]);
                if (category_id == id)
                {
                    result = dr["name"].ToString();
                }
            }
            return result;
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

    }
}