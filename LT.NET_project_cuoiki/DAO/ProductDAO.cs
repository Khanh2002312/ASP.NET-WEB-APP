using LT.NET_project_cuoiki.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace LT.NET_project_cuoiki.dao
{
    public class ProductDAO
    {
        public List<ProductEntity> getAllProduct()
        {
            List<ProductEntity> products = new List<ProductEntity>();

            ConnectionMysql c = new ConnectionMysql();
            var d = c.SQL_query_to_DataTable("SELECT * FROM product");
            foreach (DataRow r in d.Rows)
            {
                ProductEntity product = new ProductEntity();
                product.Id = Int32.Parse(r["id"].ToString());
                product.Category = r["category_id"].ToString();
                product.Title = r["title"].ToString();
                product.Keyword = r["keyword"].ToString();
                product.Price = Int32.Parse(r["price"].ToString());
                
                product.Discount = Int32.Parse(r["discount"].ToString());
                product.Design = r["design"].ToString();
                product.Thumbnail = r["thumbnail"].ToString();
                product.Description = r["description"].ToString();
                product.Quantity = Int32.Parse(r["quantity"].ToString());
                product.Is_on_sale = Int32.Parse(r["is_on_sale"].ToString());
                products.Add(product);
            }
            return products;
        }
        public ProductEntity getProductById(string id)
        {
            ProductEntity product = new ProductEntity();
            ConnectionMysql c = new ConnectionMysql();
            var d = c.SQL_query_to_DataTable("SELECT * FROM product WHERE product.id = " + id);
            foreach (DataRow r in d.Rows)
            {
                product.Id = Int32.Parse(r["id"].ToString());
                product.Category = r["category_id"].ToString();
                product.Title = r["title"].ToString();
                product.Keyword = r["keyword"].ToString();
                product.Price = Int32.Parse(r["price"].ToString());
                product.Discount = Int32.Parse(r["discount"].ToString());
                product.Design = r["design"].ToString();
                product.Thumbnail = r["thumbnail"].ToString();
                product.Description = r["description"].ToString();
                product.Quantity = Int32.Parse(r["quantity"].ToString());
                product.Is_on_sale = Int32.Parse(r["is_on_sale"].ToString());

            }
            return product;
        }

        public string getCategoryName(String id)
        {
            string result = "";
            ConnectionMysql c = new ConnectionMysql();
            var d = c.SQL_query_to_DataTable("SELECT * FROM category WHERE category.id = (SELECT category.parent_id FROM category  WHERE category.id = (SELECT product.category_id FROM product WHERE product.id = " + id + ")) ");
            foreach (DataRow r in d.Rows)
            {
                result = r["name"].ToString();
            }
            return result;
        }
        public string getGem(String id)
        {
            string result = "";
            ConnectionMysql c = new ConnectionMysql();
            var d = c.SQL_query_to_DataTable("SELECT* FROM category WHERE category.id = (SELECT product.category_id FROM product WHERE product.id = " + id + ")");
            foreach (DataRow r in d.Rows)
            {
                result = r["name"].ToString();
            }
            return result;
        }

    }
}